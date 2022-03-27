using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeIndicator : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxGrade(float grade)
    {
        slider.maxValue = grade;
        slider.value = grade;

        fill.color = gradient.Evaluate(0f);
    }

    public void SetGrade(float grade)
    {

        slider.value = grade;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
