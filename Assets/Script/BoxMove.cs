using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Box
{
    public class BoxMove : MonoBehaviour
    {
        [SerializeField]
        [Header("オブジェクト回転速度")]
        private float speed = 5.0f;
        [SerializeField]
        [Header("最大角度")]
        private float maxAngles = 5.0f;

        [SerializeField]
        [Header("マウス操作？")]
        private bool trueMouse = true;

        [Header("マウス操作？")]
        public Toggle toggle;

        //位置座標(コントローラー用)
        [HideInInspector]
        public float x = 0.0f, y = 0.0f,z = 0.0f;

        //位置履歴
        private float tx = 0.0f, ty = 0.0f, tz = 0.0f;

        //座標更新
        private void TransformAssignment()
        {
            tx = transform.eulerAngles.x;
            ty = transform.eulerAngles.y;
            tz = transform.eulerAngles.z;
        }

        //角度正規化
        private bool AnglesNormalize(float angle)
        {
            bool flag = false;

            // 現在のGameObjectのY軸方向の角度を取得
            float currentAngle = angle;
            // 現在の角度が180より大きい場合
            if (currentAngle > 180)
            {
                // デフォルトでは角度は0～360なので-180～180となるように補正
                currentAngle = currentAngle - 360;
            }

            //Debug.Log(currentAngle);

            if (Mathf.Abs(currentAngle) > maxAngles)
            {
                flag = true;
            }

            //もし最大角度より上を行っていたらtrueを返す
            return flag;
        }

        //座標を振り切らない用の関数
        private void TransformCheck()
        {
            //もし最大角度より上を行っていたらtrueを返す
            if (AnglesNormalize(transform.eulerAngles.x))
            {
                this.transform.rotation = Quaternion.Euler(tx, transform.eulerAngles.y, transform.eulerAngles.z);
            }

            if (AnglesNormalize(transform.eulerAngles.y))
            {
                this.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, ty, transform.eulerAngles.z);
            }

            if (AnglesNormalize(transform.eulerAngles.z))
            {
                this.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, tz);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            trueMouse = toggle.isOn;

            if (trueMouse)
            {
                // x軸を軸、z軸を軸にして、回転させるQuaternionを作成（変数をrotとする）
                Quaternion rot = Quaternion.Euler(Input.GetAxis("Mouse Y") * speed, 0, -Input.GetAxis("Mouse X") * speed);
                // 現在の自信の回転の情報を取得する。
                Quaternion q = this.transform.rotation;
                // 合成して、自身に設定
                this.transform.rotation = q * rot;
            }
            else
            {
                //Debug.Log("x = " + x + "y = " + y + "z = " + z);
                Quaternion rotation = Quaternion.Euler(-y, x, z);
                gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotation, .25f);
            }

            //座標が変なところに言ってないかのチェック
            TransformCheck();
            //座標格納
            TransformAssignment();
        }
    }

}