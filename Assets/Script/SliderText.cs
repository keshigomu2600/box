using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [Header("対象シリンダー")]
    public Slider hpSlider;

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "落とす数：" + hpSlider.value;
    }
}
