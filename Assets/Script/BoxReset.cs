using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReset : MonoBehaviour
{
    [Header("向きをリセットさせたいもの")]
    public GameObject resetTarget;

    [HideInInspector]
    public bool resetFlag = false;

    //位置リセット関数
    public void ButtonBoxReset()
    {
        resetTarget.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        resetFlag = true;
    }
}
