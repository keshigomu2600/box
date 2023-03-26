using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public int[] sw = new int[3];
    public int[] swPre = new int[3];
    public int vol;

    float moveValue;
    float jampValue;

    void MovePlayer()
    {
        //ˆÚ“®
        if (Input.GetKey(KeyCode.RightArrow) || sw[0] == 0)
            this.transform.position += new Vector3(moveValue, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow) || sw[1] == 0)
            this.transform.position += new Vector3(-moveValue, 0f, 0f);

        //ƒWƒƒƒ“ƒv
        if (Input.GetKeyDown(KeyCode.Z) || (swPre[2] == 0 && sw[2] == 1))
            GetComponent<Rigidbody>().velocity = Vector3.up * jampValue;

        for (int i = 0; i < swPre.Length; i++)
        {
            swPre[i] = sw[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        moveValue = 0.1f;
        jampValue = 5.0f;

        debugText.text = "debug";

        //OFF‚È‚Ì‚Å1
        for (int i = 0; i < sw.Length; i++)
        {
            sw[i] = 1;
            swPre[i] = 1;
        }
        //“K“–
        vol = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string str = string.Format("vol:{0},sw:{1}{2}{3}", vol, sw[0], sw[1], sw[2]);
        debugText.text = str;

        MovePlayer();
    }
}

