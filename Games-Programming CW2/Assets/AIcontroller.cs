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
    public float count5;
    public float count6;
    public float count7;
    public float count8;
    public bool actionTriggered;
    public bool actionTriggered2;
    public bool actionTriggered3;
    public bool actionTriggered4;
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
        count5 = 0;
        actionTriggered = false;
        actionTriggered2 = false;
        actionTriggered3 = false;
        actionTriggered4 = false;
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
            actionTriggered = true;
            cd = true;
            gradeTracker.DecreaseGrade(20);
            displayObject.AlarmActive = false;
    }
        if(displayObject.ThudActive == true){
            actionTriggered2 = true;
            cd = true;
            gradeTracker.DecreaseGrade(5);
            displayObject.ThudActive = false;
    }
        if(playerCough.CoughActive == true){
            actionTriggered3 = true;
            cd = true;
            gradeTracker.DecreaseGrade(7);
            playerCough.CoughActive = false;
    }
        if(displayObject.StartActive == true){
            actionTriggered4 = true;
       
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

     void FixedUpdate() {
          if(count5 < 2 && actionTriggered == true){
            count5++;
            if(count5 > 1  ){
                count5 = 0;
                actionTriggered = false;
            }
        }
        if(count6 < 2 && actionTriggered2 == true){
            count6++;
            if(count6 > 1  ){
                count6 = 0;
                actionTriggered2 = false;
            }
        }
        if(count7 < 2 && actionTriggered3 == true){
            count7++;
            if(count7 > 1  ){
                count7 = 0;
                actionTriggered3 = false;
            }
        }
        if(count8 < 2 && actionTriggered4 == true){
            count8++;
            if(count8 > 1   ){
                count8 = 0;
                actionTriggered4 = false;
            }
        }
        
    }
}