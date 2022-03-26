using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;
    public float Speed = 5f;
    public float JumpVelocity = 3f;
    public float JumpHeight = 0f;
    private bool CoolDown;
    public Rigidbody _body;
    private Vector3 moveDirection;
    private Vector3 JumpUp;
    private Vector3 moveDirection3;
    private bool restart;

  

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>(); //get the rigidbody component of the player
        _body.freezeRotation = true; //freeze the rotation
        CoolDown = false; //cooldown set to false initially for jumping

        
    }

    // Update is called once per frame
    void Update()
    {
        //get the user inputs
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float y = Input.GetAxisRaw("Jump");

        //get direction of jump
        JumpUp = transform.up * y;

        //check for user input and check for limiting the users jump height and check for jump cooldown
        if(Input.GetKey(KeyCode.Space) && JumpHeight < 35 && CoolDown == false){    
            _body.AddForce(JumpUp * this.JumpVelocity, ForceMode.Impulse); //add force to jump using impulse for a fast jump
            JumpHeight++; //increase jump height till it reaches limit
        }
        
           
        moveDirection = transform.forward * z + transform.right * x; //find direction of movement

        if(Input.GetKeyUp(KeyCode.Space)){ //when spacebar is released jumping goes on cooldown
            CoolDown = true;
            JumpHeight = 0;  
        }
        if(Input.GetKey(KeyCode.LeftShift)){ //check for user input to allow for running
            this.Speed = 5f;
        } else {
            this.Speed = 3f;
        }
    }

    


    void FixedUpdate() {
        _body.AddForce(moveDirection.normalized * this.Speed * 5, ForceMode.Acceleration); //add force to move player 

        
   
    }


}