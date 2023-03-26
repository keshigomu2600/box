using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RespornPoint
{
    //���X�|�[���ʒu
    [System.Serializable]
    public struct RespornObjectPoint
    {
        //�ő�l
        public GameObject maxPoint;
        //�ŏ��l
        public GameObject minPoint;
    }

    public class Resporn : MonoBehaviour
    {
        public Slider sliderCompornent;
        [SerializeField]
        [Header("���X�|�[���n�_(�ő�ʒu�A�ŏ��ʒu)")]
        private RespornObjectPoint[] respornObj;
        [Header("���Ƃ�����")]
        public GameObject[] fallObj;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //�I�u�W�F�N�g�������_���ŏo��������
        public void ApperObj()
        {
            for(int i = 0;i< sliderCompornent.value;i++)
            {
                //�����̃��X�|�[���n�_�������߂�
                int respornPoint = Random.Range(0, respornObj.Length);

                //���ۂǂ̒n�_�ɐ������邩���߂�
                float maxX = respornObj[respornPoint].maxPoint.transform.position.x;
                float minX = respornObj[respornPoint].minPoint.transform.position.x;
                float maxZ = respornObj[respornPoint].maxPoint.transform.position.z;
                float minZ = respornObj[respornPoint].minPoint.transform.position.z;

                Vector3 pos = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));

                //�ǂ̃I�u�W�F�N�g���o�������邩���߂�
                int fallObjIndex = Random.Range(0, fallObj.Length);

                // �v���n�u���w��ʒu�ɐ���
                Instantiate(fallObj[fallObjIndex], pos, Quaternion.identity);
            }
        }
    }

}