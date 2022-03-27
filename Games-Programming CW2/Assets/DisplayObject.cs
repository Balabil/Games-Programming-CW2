using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script handles all interactions with objects (mainly obstacles such as boxes) around the level, additionally this script contains the win condition*/
public class DisplayObject : MonoBehaviour

{

    public float idetifyRange = 50f;
    private string nameObject;
    private bool hitObject;
    private GameObject desk;
    public GameObject Invigilator;
    public AudioSource Thud;
    public AudioSource FireAlarm;
    public AudioSource WindowsStart;
    public bool ThudActive;
    public bool AlarmActive;
    public bool AlarmUsed;
    public bool StartActive;
    public bool cd;
    public bool cd2;
    private int count;
    private int count2;
    public float count3;
    public float count4;
    AIcontroller aiController;
    // Update is called once per frame
    
    void Start(){
        ThudActive = false;
        AlarmActive = false;
        AlarmUsed = false;
        StartActive = false;
        cd = false;
        count = 0;
        count2 = 0;
        count3 = 0f;
        count4 = 0f;
        Time.timeScale = 1f;
        aiController = Invigilator.GetComponent<AIcontroller>();
    }
    void Update()

    {
            hitObject = false;
            RaycastHit hit2;
            /* Sends out ray from the camera attatched to my player*/                                
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit2, idetifyRange))

                {
                    if(cd == true && count3 < 5){
                        count3 = count3 + Time.deltaTime;
                        if(count3 >= 5){
                            count3 = 0;
                            cd = false;
            }
                    }
                    if(cd2 == true && count4 < 30){
                        count4 = count4 + Time.deltaTime;
                        if(count4 >= 30){
                            count4 = 0;
                            cd2 = false;
            }
        }
                        /*if(count == 1){
                            count = 0;
                            ThudActive = false;
                        }
                        if(count2 == 1){
                            count2 = 0;
                            AlarmActive = false;
                        }
                        /*Checks if the ray hit a movable object*/
                        if(hit2.collider.gameObject.tag != "Untagged" && hit2.collider.gameObject.tag != "Obstacle" && hit2.collider.gameObject.tag != "Enemy" && hit2.collider.gameObject.tag != "Bullet")
                        {
                            //sets hit object to true to allow the gui to show the user they can interact with the object
                            hitObject = true;
                            if (hit2.collider.gameObject.tag == "Alarm" && AlarmUsed == false){
                                nameObject = "Press E to Activate Alarm";
                                }
                            if (hit2.collider.gameObject.tag == "Table"){
                                nameObject = "Press E to Kick Table";
                                }
                            if (hit2.collider.gameObject.tag == "Computer"){
                                nameObject = "Press E to Start Computer";
                                }
                            if (Input.GetKeyDown("e") && hit2.collider.gameObject.tag == "Table" && cd == false){
                                desk = hit2.collider.gameObject;
                                Kick();
                                ThudActive = true;
                                cd = true;
                                count3++;
                                } 
                            if (Input.GetKeyDown("e") && hit2.collider.gameObject.tag == "Alarm" && AlarmUsed == false){
                                Alarm();
                                AlarmActive = true;
                                AlarmUsed = true;
                                count2++;
                                }
                            if (Input.GetKeyDown("e") && hit2.collider.gameObject.tag == "Computer" && cd2 == false){
                                Windows();
                                StartActive = true;
                                cd2 = true;
                                count4++;
                                }

                        }
                        //if statement that handles the win condition, the player must be in possession of the key, have found and interacted with the door and killed the boss monster

                } 
    }
        

    void OnGUI()
    {
        if (hitObject == true) //check to see if user is looking at an object they can interact with
        {
 
            GUI.Box(new Rect(Screen.width/2, Screen.height/2, Screen.width/8, Screen.height/35), nameObject);
        }
    }

    void Kick()
    {
        Thud.Play();
        desk.GetComponent<Rigidbody>().AddForce(2200 * transform.up *-1, ForceMode.Acceleration);
    }
    void Alarm()
    {
        FireAlarm.Play();
    }
    void Windows()
    {
        WindowsStart.Play();
    }
}


    /* function to release the object */

