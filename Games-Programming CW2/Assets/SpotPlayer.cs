using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Camera;
    public GameObject Invigilator;
    DisplayObject displayObject;
    Gun gun;
    PlayerCough playerCough;
    AIcontroller aiController;
    void Start()
    {
        displayObject = Camera.GetComponent<DisplayObject>();
        gun = Camera.GetComponent<Gun>();
        playerCough = Player.GetComponent<PlayerCough>();
        aiController = Invigilator.GetComponent<AIcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           if((aiController.actionTriggered == true)||(aiController.actionTriggered2 == true)||(aiController.actionTriggered3 == true)||(aiController.actionTriggered4 == true) || (gun.actionTriggered == true)){
                Debug.Log("Player Dead");
            }
        }
    }
    /*
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if((aiController.actionTriggered == true)||(aiController.actionTriggered2 == true)||(aiController.actionTriggered3 == true)||(aiController.actionTriggered4 == true) ){
                Debug.Log("Player Dead");
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           if((aiController.actionTriggered == true)||(aiController.actionTriggered2 == true)||(aiController.actionTriggered3 == true)||(aiController.actionTriggered4 == true) ){
                Debug.Log("Player Dead");
            }
        }
    }
    */
}
