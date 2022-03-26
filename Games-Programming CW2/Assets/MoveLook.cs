using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLook : MonoBehaviour
{
    public float mouseSensitivity = 400f;

    public Transform playerBody;
    public Transform playerHead;

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    { 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        xRotation += mouseX;

        Quaternion rotation = playerBody.rotation; //set the quaternion to playerbody
        rotation.eulerAngles = new Vector3(0, xRotation, 0); //set new rotation depending on input recieved from mouse's x axis 
        playerBody.rotation = rotation; //set players body to the new calculated rotation
        /* same as above but rotates only players head */
        Quaternion rotation2 = playerHead.rotation;
        rotation2.eulerAngles = new Vector3(yRotation, xRotation, 0);
        playerHead.rotation = rotation2;




        
    }
}
