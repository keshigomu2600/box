using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public RespornPoint.Resporn resporn;
    public PointAdd.AddPoint addPoint;

    [Header("アニメーター")]
    public Animator clearUI;

    [HideInInspector]
    public int point = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(point >= resporn.sliderCompornent.value)
        {
            clearUI.SetTrigger("Trigger");
            resporn.ApperObj();
            point = 0;
        }
    }
}
