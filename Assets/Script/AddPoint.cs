using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PointAdd
{
    public class AddPoint : MonoBehaviour
    {
        [Header("ポイントを表示させるテキスト")]
        public Text pointText;
        [Header("コンボ適応時間")]
        public float countTime = 3.0f;
        [Header("何コンボまで効果音の種類を増やすか")]
        public int SEIndex = 4;

        public GameClear gameClear;

        [HideInInspector]
        public List<bool> SEFlag = new List<bool>();
        [HideInInspector]
        public int num = 0;

        [HideInInspector]
        public int point = 0;
        private int oldPoint = 0;
        private float time = 0;
        private bool pointFlag = false;

        void ResetTime()
        {
            time = countTime;
        }

        //ポイントアップ
        void PointUp()
        {
            pointFlag = true;
            if (point < 1000)
            {
                point++;
                gameClear.point++;
            }
        }

        void ComboTime()
        {
            time -= Time.deltaTime;

            //時間以内にポイントが入ったら時間継続
            if (point > oldPoint)
            {
                //コンボ数に見合った効果音を鳴らす(DoSomething側で)
                if(num < SEIndex)
                {
                    SEFlag[num] = true;
                }
                else
                {
                    //めっちゃコンボしたら最大コンボ時の効果音を流す
                    SEFlag[SEIndex - 1] = true;
                }

                Debug.Log(++num + "コンボ！");

                ResetTime();
                oldPoint = point;
            }

            //時間切れになってもポイントが入らなかったら終了
            if (time <= 0.0f)
            {
                num = 0;
                pointFlag = false;
                ResetTime();
            }
        }

        void Start()
        {
            ResetTime();

            for (int i = 0; i < SEIndex; i++) 
            {
                SEFlag.Add(false);
            }
        }

        void Update()
        {
            //コンボ中かどうか
            if(pointFlag)
            {
                ComboTime();
            }
        }

        //テキスト更新
        void textUpdate()
        {
            pointText.text = point + "個";
        }

        //オブジェクトがヒットしたときにポイントアップ
        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Object")
            {
                //ポイントアップ
                PointUp();

                //テキスト更新
                textUpdate();

                //そのオブジェクトは廃棄
                Destroy(other.gameObject);
            }
        }
    }
}
