using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PointAdd
{
    public class AddPoint : MonoBehaviour
    {
        [Header("�|�C���g��\��������e�L�X�g")]
        public Text pointText;
        [Header("�R���{�K������")]
        public float countTime = 3.0f;
        [Header("���R���{�܂Ō��ʉ��̎�ނ𑝂₷��")]
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

        //�|�C���g�A�b�v
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

            //���Ԉȓ��Ƀ|�C���g���������玞�Ԍp��
            if (point > oldPoint)
            {
                //�R���{���Ɍ����������ʉ���炷(DoSomething����)
                if(num < SEIndex)
                {
                    SEFlag[num] = true;
                }
                else
                {
                    //�߂�����R���{������ő�R���{���̌��ʉ��𗬂�
                    SEFlag[SEIndex - 1] = true;
                }

                Debug.Log(++num + "�R���{�I");

                ResetTime();
                oldPoint = point;
            }

            //���Ԑ؂�ɂȂ��Ă��|�C���g������Ȃ�������I��
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
            //�R���{�����ǂ���
            if(pointFlag)
            {
                ComboTime();
            }
        }

        //�e�L�X�g�X�V
        void textUpdate()
        {
            pointText.text = point + "��";
        }

        //�I�u�W�F�N�g���q�b�g�����Ƃ��Ƀ|�C���g�A�b�v
        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Object")
            {
                //�|�C���g�A�b�v
                PointUp();

                //�e�L�X�g�X�V
                textUpdate();

                //���̃I�u�W�F�N�g�͔p��
                Destroy(other.gameObject);
            }
        }
    }
}
