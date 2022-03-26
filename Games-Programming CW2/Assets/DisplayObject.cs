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

    // Update is called once per frame
    

    void Update()

    {
            hitObject = false;
            RaycastHit hit2;
            /* Sends out ray from the camera attatched to my player*/                                
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit2, idetifyRange))

                {
                        /*Checks if the ray hit a movable object*/
                        if(hit2.collider.gameObject.tag != "Untagged" && hit2.collider.gameObject.tag != "Obstacle" && hit2.collider.gameObject.tag != "Enemy" && hit2.collider.gameObject.tag != "Bullet")
                        {
                            //sets hit object to true to allow the gui to show the user they can interact with the object
                            hitObject = true;
                            nameObject = "Press E to Kick Desk"; 

                        }
                        //if statement that handles the win condition, the player must be in possession of the key, have found and interacted with the door and killed the boss monster

                } 
    }
        

    void OnGUI()
    {
        if (hitObject == true) //check to see if user is looking at an object they can interact with
        {
 
            GUI.Box(new Rect(Screen.width/2, Screen.height/2, Screen.width/10, Screen.height/35), nameObject);
        }
    }
}


    /* function to release the object */

