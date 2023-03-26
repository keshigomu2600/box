using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombAnimation : ComboText
{
    [Header("アニメーター")]
    public Animator animator;

    private int oldPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        oldPoint = addPoint.num;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldPoint != addPoint.num && addPoint.num != 0)
        {
            animator.SetTrigger("Trigger");
        }

        oldPoint = addPoint.num;
    }
}
