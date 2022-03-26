using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce;
    bool canShoot;
    public Camera PlayerCamera;
    public Transform point;



    private void Update()
    {
        PlayerInput();
    }
     
    private void PlayerInput()
    {
        
        canShoot = Input.GetKeyDown(KeyCode.Mouse0); //check to see if user cliecked down on left mouse button
        //start the shooting process
        if (canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        //Starts by finding the exact hit point with the use of a raycast
        Ray ray = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        /*check to see if something has been hit by the ray*/
        Vector3 hitPoint;
        if (Physics.Raycast(ray, out hit)){
            hitPoint = hit.point; //sets the target point to be the point hit by the ray
        }
        else {
            hitPoint = ray.GetPoint(75); //Just a point far away from the player
        }
        //Calculate direction from attackPoint to targetPoint
        Vector3 direction = hitPoint - point.position;
        GameObject currentBullet = Instantiate(bullet, point.position, Quaternion.identity); 
        currentBullet.transform.forward = direction.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

    }
 
}
