using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(float x)
    {
        slider.maxValue = x;
        slider.value = x;
    }

    public void SetHealth(float x)
    {
        slider.value = x;
    }
}
