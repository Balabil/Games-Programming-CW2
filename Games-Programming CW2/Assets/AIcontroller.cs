using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour
{


    NavMeshAgent agent;


    public GameObject gamePoints;
    Transform[] points;
    private int destPoint = 0;
    DisplayObject displayObject;
    public BoxCollider[] detection;
    public Transform player;
    private bool cd;
    private float count;
    public GameObject Camera;
    public GameObject Player;
    GradeTracker gradeTracker;
    public float limit;
    PlayerCough playerCough;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
     
        //stops the agent from stopping
        agent.autoBraking = false;
        //gets the transform of compents that are children of the object
        points = gamePoints.GetComponentsInChildren<Transform>();
        GotoNextPoint();
        cd = false;
        Time.timeScale = 1f;
        count = 0;
        displayObject = Camera.GetComponent<DisplayObject>();
        gradeTracker = Player.GetComponent<GradeTracker>();
        playerCough = Player.GetComponent<PlayerCough>();
        limit = 0;
    }

    //This code was taken from https://docs.unity3d.com/Manual/nav-AgentPatrol.html
    void GotoNextPoint()
    {
        //checks that there is points to go to
        if (points.Length == 0)

            return;

        //sets the destination point the desired location
        agent.destination = points[destPoint].position;
        //selects a new point to go to
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(displayObject.AlarmActive == true){
            cd = true;
            gradeTracker.DecreaseGrade(20);
            displayObject.AlarmActive = false;
    }
        if(displayObject.ThudActive == true){
            cd = true;
            gradeTracker.DecreaseGrade(5);
            displayObject.ThudActive = false;
    }
        if(playerCough.CoughActive == true){
            cd = true;
            gradeTracker.DecreaseGrade(3);
            playerCough.CoughActive = false;
    }
        if(displayObject.StartActive == true && limit < 2){
            limit++;
            cd = true;
            gradeTracker.DecreaseGrade(15);
            displayObject.StartActive = false;
    }
        if(cd == true && count < 3){
            count = count + Time.deltaTime;
            agent.destination = transform.position;
            transform.LookAt(player);
            if(count >= 3){
                count = 0;
                cd = false;
            }
        }
        //calculates the distance from the player

        //if the distance is less than 15 execute case 1, false execute case 2



                //if the agent is not searching for a path and the distance between the destination is less than 0.5
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
                
        


    }
}