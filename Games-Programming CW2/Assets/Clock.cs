using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform clockHandTransfrom;
    void Start()
    {
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        clockHandTransfrom.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup* 6f);
    }
}
