using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeTracker : MonoBehaviour
{
    public float maxGrade = 100;
    public float currentGrade;
    public GameObject Camera;
    DisplayObject displayObject;
    public GradeIndicator gradeIndicator;
    private float count;
    void Start()
    {
        currentGrade = maxGrade;
        gradeIndicator.SetMaxGrade(maxGrade);
        displayObject = Camera.GetComponent<DisplayObject>();
        Time.timeScale = 1f;
        count = 0;
    }

    void Update()
    {
    if(count < 1){
        count += Time.deltaTime;
        if(count >= 1){
            count = 0;
            IncreaseGrade(0.5f);
        }
    }
}
    
    
    public void DecreaseGrade(float damage)
    {
        currentGrade -= damage;
        gradeIndicator.SetGrade(currentGrade);
    }

  
    public void IncreaseGrade(float damage)
    {
        currentGrade += damage;
        gradeIndicator.SetGrade(currentGrade);
    }
}
