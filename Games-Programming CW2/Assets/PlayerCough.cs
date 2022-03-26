using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCough : MonoBehaviour
{
    // Update is called once per frame
    public AudioSource Cough;
    void Update()
    {
        if (Input.GetKeyDown("space")){
            PlayCough();
        }
    }
    public void PlayCough(){
        Cough.Play();
    }
}