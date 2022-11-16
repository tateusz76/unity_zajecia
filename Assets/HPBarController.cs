using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
public Slider slider;

    public void setHP(int health)
    {
        slider.value = health;
    }

    public void setMaxHP(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
