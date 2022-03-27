using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageContoller : MonoBehaviour
{
    // Start is called before the first frame update

    public Image fireAlarm;
    public Image waterGun;
    public Image kick;
    public Image computer;
    public Image cough;
    public GameObject player;
    private PlayerCough playerCough;
    public GradeIndicator kickSlider;
    public GradeIndicator coughSlider;
    public GradeIndicator waterSlider;
    public GradeIndicator computerSlider;
    public GameObject camera;
    private DisplayObject displayObject;
    private Gun gun;
    void Start()
    {
        displayObject = camera.GetComponent<DisplayObject>();
        gun = camera.GetComponent<Gun>();
        playerCough = player.GetComponent<PlayerCough>();
        kickSlider.SetMaxValue(5);
        coughSlider.SetMaxGrade(3);
        waterSlider.SetMaxGrade(5);
        computerSlider.SetMaxValue(30);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayObject.AlarmUsed)
        {
            fireAlarm.color = new Color(255, 255, 255, 0.5f);
        }

        if (displayObject.cd == true && displayObject.count3 < 5)
        {
            kick.color = new Color(255, 255, 255, 0.5f);
            kickSlider.SetValue(displayObject.count3);

        }
        else
        {
            kick.color = new Color(255, 255, 255, 1f);
        }

        if (displayObject.cd2 == true && displayObject.count4 < 30)
        {
            computer.color = new Color(255, 255, 255, 0.5f);
            computerSlider.SetValue(displayObject.count4);
        }
        else
        {
            computer.color = new Color(255, 255, 255, 1f);
        }
        if (playerCough.cd == true && playerCough.count < 3)
        {
            cough.color = new Color(255, 255, 255, 0.5f);
            coughSlider.SetValue(playerCough.count);
        }
        else
        {
            cough.color = new Color(255, 255, 255, 1f);
        }
        if (gun.cd == true && gun.count2 < 5)
        {
            waterGun.color = new Color(255, 255, 255, 0.5f);
            waterSlider.SetValue(gun.count2);
        }
        else
        {
            waterGun.color = new Color(255, 255, 255, 1f);
        }
    }
}
