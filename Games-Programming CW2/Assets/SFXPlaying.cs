using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource Cough;

    public void PlayCough(){
        Cough.Play();
    }

}

