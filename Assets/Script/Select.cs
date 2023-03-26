using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("�Q�[���{�҂�UI")]
    public GameObject gameUI;
    [Header("�^�C�g����UI")]
    public GameObject titleUI;
    [Header("�J����")]
    public GameObject cameraObj;
    [Header("�{�҈ړ���")]
    public GameObject target;
    public RespornPoint.Resporn resporn;

    float step = 25f;
    bool mainFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        titleUI.SetActive(true);
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(mainFlag && cameraObj.transform.position != target.transform.position)
        {
            cameraObj.transform.position = Vector3.MoveTowards(cameraObj.transform.position, target.transform.position, step * Time.deltaTime);
        }
    }

    public void GameStart()
    {
        titleUI.SetActive(false);
        mainFlag = true;
        gameUI.SetActive(true);
        resporn.ApperObj();
    }
}
