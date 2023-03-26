// Unityでシリアル通信、Arduinoと連携する雛形

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{
    // 制御対象のオブジェクト用に宣言しておいて、Start関数内で名前で検索
    [Header("対象のオブジェクト")]
    public GameObject targetObject;
    [Header("リセットボタン")]
    public BoxReset box;
    [Header("ポイント効果音用")]
    public PointAdd.AddPoint add;

    Box.BoxMove targetScript;

    // シリアル通信のクラス、クラス名は正しく書くこと
    SerialHandle serialHandler;

    void PointUp()
    {
        //ポイントアップ
        if (add.SEFlag[0])
        {
            serialHandler.Write("p");
            add.SEFlag[0] = false;
        }
        if (add.SEFlag[1])
        {
            serialHandler.Write("1");
            add.SEFlag[1] = false;
        }
        if (add.SEFlag[2])
        {
            serialHandler.Write("2");
            add.SEFlag[2] = false;
        }
        if (add.SEFlag[3])
        {
            serialHandler.Write("3");
            add.SEFlag[3] = false;
        }
    }

    void Start()
    {
        // 制御対象に関連付けられたスクリプトを取得。
        targetScript = targetObject.GetComponent<Box.BoxMove>();
        serialHandler = GetComponent<SerialHandle>();

        // 信号受信時に呼ばれる関数としてOnDataReceived関数を登録
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        //文字列を送信するなら例えばココ
        //serialHandler.Write("hogehoge");
        //リセット
        if(box.resetFlag)
        {
            serialHandler.Write("r");
            box.resetFlag = false;
        }

        PointUp();
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        // ここでデコード処理等を記述
        if (message == null)
            return;

        // 受け取ったデータを数値に変換 
        if (message[0] == 'S' && message[message.Length - 1] == 'E' && !box.resetFlag)
        {
            #region 必要に応じて変更すべき箇所

            string receivedData;
            int t;

            // 必要な文字部分のバイト数（範囲）は常に把握する
            //receivedData = message.Substring(x, y); // x文字目からy文字数を変換

            // 必要な文字部分を抽出したら、データ形式に合わせてデコード、例えば以下のように。
            //float.TryParse(receivedData, out data);

            //x座標
            receivedData = message.Substring(1, 4);
            int.TryParse(receivedData, out t);
            targetScript.x = t;

            //y座標
            receivedData = message.Substring(5, 4);
            int.TryParse(receivedData, out t);
            targetScript.y = t;

            //z座標
            receivedData = message.Substring(9, 4);
            int.TryParse(receivedData, out t);
            targetScript.z = t;

            #endregion
        }
    }
}
