using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_UI : MonoBehaviour
{
    public Image fill;

    public void UpdateFill(float current_time, float max_time)
    {
        fill.fillAmount = (max_time - current_time)/10;
    }
}
