// Unity�ŃV���A���ʐM�AArduino�ƘA�g���鐗�`

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{
    // ����Ώۂ̃I�u�W�F�N�g�p�ɐ錾���Ă����āAStart�֐����Ŗ��O�Ō���
    [Header("�Ώۂ̃I�u�W�F�N�g")]
    public GameObject targetObject;
    [Header("���Z�b�g�{�^��")]
    public BoxReset box;
    [Header("�|�C���g���ʉ��p")]
    public PointAdd.AddPoint add;

    Box.BoxMove targetScript;

    // �V���A���ʐM�̃N���X�A�N���X���͐�������������
    SerialHandle serialHandler;

    void PointUp()
    {
        //�|�C���g�A�b�v
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
        // ����ΏۂɊ֘A�t����ꂽ�X�N���v�g���擾�B
        targetScript = targetObject.GetComponent<Box.BoxMove>();
        serialHandler = GetComponent<SerialHandle>();

        // �M����M���ɌĂ΂��֐��Ƃ���OnDataReceived�֐���o�^
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        //������𑗐M����Ȃ�Ⴆ�΃R�R
        //serialHandler.Write("hogehoge");
        //���Z�b�g
        if(box.resetFlag)
        {
            serialHandler.Write("r");
            box.resetFlag = false;
        }

        PointUp();
    }

    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        // �����Ńf�R�[�h���������L�q
        if (message == null)
            return;

        // �󂯎�����f�[�^�𐔒l�ɕϊ� 
        if (message[0] == 'S' && message[message.Length - 1] == 'E' && !box.resetFlag)
        {
            #region �K�v�ɉ����ĕύX���ׂ��ӏ�

            string receivedData;
            int t;

            // �K�v�ȕ��������̃o�C�g���i�͈́j�͏�ɔc������
            //receivedData = message.Substring(x, y); // x�����ڂ���y��������ϊ�

            // �K�v�ȕ��������𒊏o������A�f�[�^�`���ɍ��킹�ăf�R�[�h�A�Ⴆ�Έȉ��̂悤�ɁB
            //float.TryParse(receivedData, out data);

            //x���W
            receivedData = message.Substring(1, 4);
            int.TryParse(receivedData, out t);
            targetScript.x = t;

            //y���W
            receivedData = message.Substring(5, 4);
            int.TryParse(receivedData, out t);
            targetScript.y = t;

            //z���W
            receivedData = message.Substring(9, 4);
            int.TryParse(receivedData, out t);
            targetScript.z = t;

            #endregion
        }
    }
}
