using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeTracker : MonoBehaviour
{
    public int maxGrade = 100;
    public int currentGrade;
    public GameObject Camera;
    DisplayObject displayObject;
    public GradeIndicator gradeIndicator;
    void Start()
    {
        currentGrade = maxGrade;
        gradeIndicator.SetMaxGrade(maxGrade);
        displayObject = Camera.GetComponent<DisplayObject>();
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseGrade(1);
    }
       if(displayObject.ThudActive == true){
        DecreaseGrade(5);
    }
        }
    
    void DecreaseGrade(int damage)
    {
        currentGrade -= damage;
        gradeIndicator.SetGrade(currentGrade);
    }
}
