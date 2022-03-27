using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagPlayer : MonoBehaviour
{
    GradeTracker gradeTracker;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        gradeTracker = Player.GetComponent<GradeTracker>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Student" || collision.gameObject.tag == "Table")
        {
            gradeTracker.DecreaseGrade(1);
            this.gameObject.SetActive(false);
        }
    }
}
