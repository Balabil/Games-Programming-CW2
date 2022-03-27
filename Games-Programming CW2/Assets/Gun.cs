using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce;
    bool canShoot;
    public Camera PlayerCamera;
    public Transform point;
    private float count;
    private bool cd;
    private float count2;

    private void Start(){
        cd = false;
        count = 0;
        count2 = 0;
        Time.timeScale = 1f;
    }
    private void Update()
    {
        PlayerInput();
    }
     
    private void PlayerInput()
    {
        if(cd == true && count2 < 5){
            count2 += Time.deltaTime;
            if(count2 >= 5){
                cd = false;
                count2 = 0;
                count = 0;
            }
        }
        
        canShoot = Input.GetKeyDown(KeyCode.Mouse0); //check to see if user cliecked down on left mouse button
        //start the shooting process
        if (canShoot && count < 2 && cd == false)
        {
            count++;
            Shoot();
            Shoot();
            Shoot();
            Shoot();
            Shoot();
            if(count >= 2){
                cd = true;
            }
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
        Destroy(currentBullet,2f);
    }
 
}
