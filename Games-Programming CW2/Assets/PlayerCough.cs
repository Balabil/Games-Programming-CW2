using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCough : MonoBehaviour
{
    // Update is called once per frame
    public AudioSource Cough;
    private float count;
    private bool cd;
    public bool CoughActive;

    void Start(){
        cd = false;
        CoughActive = false;
        count = 0;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(cd == true && count < 3){
            count+=Time.deltaTime;
            if(count >= 3){
                cd = false;
                count = 0;
            }
        }
        if (Input.GetKeyDown("space") && cd == false){
            cd = true;
            CoughActive = true;
            PlayCough();
        }
    }
    public void PlayCough(){
        Cough.Play();
    }
}