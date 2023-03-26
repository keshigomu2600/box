using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReset : MonoBehaviour
{
    [Header("���������Z�b�g������������")]
    public GameObject resetTarget;

    [HideInInspector]
    public bool resetFlag = false;

    //�ʒu���Z�b�g�֐�
    public void ButtonBoxReset()
    {
        resetTarget.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        resetFlag = true;
    }
}
