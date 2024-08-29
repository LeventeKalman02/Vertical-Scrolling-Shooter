using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //this function to set the maximum amount of health for the healthbar
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //call this function to set the health amount on the healthbar
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
