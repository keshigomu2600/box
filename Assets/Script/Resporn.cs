using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RespornPoint
{
    //リスポーン位置
    [System.Serializable]
    public struct RespornObjectPoint
    {
        //最大値
        public GameObject maxPoint;
        //最小値
        public GameObject minPoint;
    }

    public class Resporn : MonoBehaviour
    {
        public Slider sliderCompornent;
        [SerializeField]
        [Header("リスポーン地点(最大位置、最小位置)")]
        private RespornObjectPoint[] respornObj;
        [Header("落とすもの")]
        public GameObject[] fallObj;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //オブジェクトをランダムで出現させる
        public void ApperObj()
        {
            for(int i = 0;i< sliderCompornent.value;i++)
            {
                //何処のリスポーン地点かを決める
                int respornPoint = Random.Range(0, respornObj.Length);

                //実際どの地点に生成するか決める
                float maxX = respornObj[respornPoint].maxPoint.transform.position.x;
                float minX = respornObj[respornPoint].minPoint.transform.position.x;
                float maxZ = respornObj[respornPoint].maxPoint.transform.position.z;
                float minZ = respornObj[respornPoint].minPoint.transform.position.z;

                Vector3 pos = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));

                //どのオブジェクトを出現させるか決める
                int fallObjIndex = Random.Range(0, fallObj.Length);

                // プレハブを指定位置に生成
                Instantiate(fallObj[fallObjIndex], pos, Quaternion.identity);
            }
        }
    }

}