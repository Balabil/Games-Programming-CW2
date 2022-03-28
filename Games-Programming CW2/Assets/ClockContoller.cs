using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClockContoller : MonoBehaviour
{
    // Start is called before the first frame update
    float countMin;
    float countSec;
    public GameObject player;
    private GradeTracker tracker;
    public TextMeshProUGUI digitalClock;
    public TextMeshProUGUI A;
    public TextMeshProUGUI B;
    public TextMeshProUGUI C;
    public TextMeshProUGUI D;
    public TextMeshProUGUI F;

    void Start()
    {
        countMin = 0;
        countSec = 0;
        Time.timeScale = 1f;
        tracker = player.GetComponent<GradeTracker>();
        A.enabled = false;
        B.enabled = false;
        C.enabled = false;
        D.enabled = false;
        F.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countMin == 3) {
            if (tracker.currentGrade > 81.75f)
            {
                
                A.enabled = true;
            }
            else if (tracker.currentGrade > 63.5f)
            {
                B.enabled = true;
            }
            else if (tracker.currentGrade > 45.25f)
            {
                C.enabled = true;
            }
            else if (tracker.currentGrade > 27f)
            {
                D.enabled = true;
            }else if(tracker.currentGrade > 0)
            {
                F.enabled = true;
            }

            Time.timeScale = 0.0f;
        }
        if(countSec >= 60)
        {
            countMin++;
            countSec = 0;
        }
        countSec = countSec + Time.deltaTime;
        if (countSec < 10)
        {
            digitalClock.SetText("0{0}:0{1}", countMin, (int)countSec);
        }
        else { digitalClock.SetText("0{0}:{1}", countMin, (int)countSec); }
    }
}
