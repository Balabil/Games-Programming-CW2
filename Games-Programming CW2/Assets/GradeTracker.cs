using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeTracker : MonoBehaviour
{
    public int maxGrade = 100;
    public int currentGrade;

    public GradeIndicator gradeIndicator;
    void Start()
    {
        currentGrade = maxGrade;
        gradeIndicator.SetMaxGrade(maxGrade);
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
    }
;
        }
    void TakeDamage(int damage)
    {
        currentGrade -= damage;
        gradeIndicator.SetGrade(currentGrade);
    }
}
