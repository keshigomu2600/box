using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [Header("�ΏۃV�����_�[")]
    public Slider hpSlider;

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "���Ƃ����F" + hpSlider.value;
    }
}
