using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Box
{
    public class BoxMove : MonoBehaviour
    {
        [SerializeField]
        [Header("�I�u�W�F�N�g��]���x")]
        private float speed = 5.0f;
        [SerializeField]
        [Header("�ő�p�x")]
        private float maxAngles = 5.0f;

        [SerializeField]
        [Header("�}�E�X����H")]
        private bool trueMouse = true;

        [Header("�}�E�X����H")]
        public Toggle toggle;

        //�ʒu���W(�R���g���[���[�p)
        [HideInInspector]
        public float x = 0.0f, y = 0.0f,z = 0.0f;

        //�ʒu����
        private float tx = 0.0f, ty = 0.0f, tz = 0.0f;

        //���W�X�V
        private void TransformAssignment()
        {
            tx = transform.eulerAngles.x;
            ty = transform.eulerAngles.y;
            tz = transform.eulerAngles.z;
        }

        //�p�x���K��
        private bool AnglesNormalize(float angle)
        {
            bool flag = false;

            // ���݂�GameObject��Y�������̊p�x���擾
            float currentAngle = angle;
            // ���݂̊p�x��180���傫���ꍇ
            if (currentAngle > 180)
            {
                // �f�t�H���g�ł͊p�x��0�`360�Ȃ̂�-180�`180�ƂȂ�悤�ɕ␳
                currentAngle = currentAngle - 360;
            }

            //Debug.Log(currentAngle);

            if (Mathf.Abs(currentAngle) > maxAngles)
            {
                flag = true;
            }

            //�����ő�p�x������s���Ă�����true��Ԃ�
            return flag;
        }

        //���W��U��؂�Ȃ��p�̊֐�
        private void TransformCheck()
        {
            //�����ő�p�x������s���Ă�����true��Ԃ�
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
                // x�������Az�������ɂ��āA��]������Quaternion���쐬�i�ϐ���rot�Ƃ���j
                Quaternion rot = Quaternion.Euler(Input.GetAxis("Mouse Y") * speed, 0, -Input.GetAxis("Mouse X") * speed);
                // ���݂̎��M�̉�]�̏����擾����B
                Quaternion q = this.transform.rotation;
                // �������āA���g�ɐݒ�
                this.transform.rotation = q * rot;
            }
            else
            {
                //Debug.Log("x = " + x + "y = " + y + "z = " + z);
                Quaternion rotation = Quaternion.Euler(-y, x, z);
                gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotation, .25f);
            }

            //���W���ςȂƂ���Ɍ����ĂȂ����̃`�F�b�N
            TransformCheck();
            //���W�i�[
            TransformAssignment();
        }
    }

}