using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WingBar : MonoBehaviour
{
    public Slider slider;

    public void SetMax(float x)
    {
        slider.maxValue = x;
        slider.value = x;
    }

    public void SetWingValue(float x)
    {
        slider.value = x;
    }
}
