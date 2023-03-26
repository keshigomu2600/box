// Unity�ŃV���A���ʐM�AArduino�ƘA�g���鐗�`
// �V���A���ʐM�𐧌䂷��N���X
// �Ⴆ�΋��GameObject�ł�����āA����Ɋ֘A�t������

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO.Ports; // �����ʂ����߂ɁAApi Compatibility Level�̐ݒ��ύX
using System.Threading;

public class SerialHandle : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    // COM10�ȏ��\\\\.\\��t�����Ȃ��ƊJ���Ȃ��B
    // portName�ɒ��ڑ������ƂȂ������s����̂ŁA�����ł�������ʂ̕ϐ��ɑ��
    string myPortName = "\\\\.\\COM12";
    public int baudRate = 57600;

    public string portName;
    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        portName = myPortName;
        Open();
    }

    void Update()
    {
        if (isNewMessageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

        serialPort_.RtsEnable = true;
        serialPort_.DtrEnable = true;

        serialPort_.Open();

        isRunning_ = true;

        thread_ = new Thread(Read);
        thread_.Start();
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive)
        {
            //thread_.Join();
            thread_.Abort();
        }

        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
        {
            try
            {
                message_ = serialPort_.ReadLine();
                isNewMessageReceived_ = true;
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try
        {
            serialPort_.Write(message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
