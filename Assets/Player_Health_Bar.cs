using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Bar : MonoBehaviour
{
    public Slider HealthSlider;

    public void SetSlider(float amount) 
    {
        HealthSlider.value = amount;
    }

    public void SetSliderMax(float amount) 
    {
        HealthSlider.maxValue = amount;
        SetSlider(amount);
    }

}
