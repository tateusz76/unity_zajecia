using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expBarController : MonoBehaviour
{
    public Slider expSlider;

        public void setEXP(int exp)
        {
            expSlider.value = exp;
        }

        public void setMaxEXP(int exp)
        {
            expSlider.maxValue = exp;
            expSlider.value = exp;
        }

        public void setMinEXP()
        {
            expSlider.minValue = expSlider.minValue - 9;
        }
}
