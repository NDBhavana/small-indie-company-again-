using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{

    public bool isDay = true;
    public bool isClock = true;
    public Material materialDay, materialNight;
    public GameObject clock;
    public GameObject ToggleText;
    public Material materialMidnight, materialNoon;
    public GameObject bliss;
    public Material blissDay, blissNight;
    private GameObject directionalLight;
    public GameObject door;
    Quaternion angleDay, angleNight;

    private void Start()
    {
        directionalLight = GameObject.Find("Directional Light");
        clock = GameObject.Find("Clock");
        bliss = GameObject.Find("Bliss");
        ToggleText = GameObject.Find("Text");
        angleDay = directionalLight.transform.rotation;
        angleNight = new Quaternion(-angleDay.x, angleDay.y, angleDay.z, angleDay.w);
    }

    public void ChangeTime()
    {
        if(isDay)
        {
            isDay = false;
            RenderSettings.skybox = materialNight;
            directionalLight.transform.rotation = angleNight;
            clock.gameObject.GetComponent<Renderer>().material = materialMidnight;
            bliss.gameObject.GetComponent<Renderer>().material = blissNight;
            ToggleText.gameObject.GetComponent<TextMeshPro>().text = "Night!";
            door.GetComponent<DoorOpening>().CallOpen();
        }
        else
        {
            isDay = true;
            RenderSettings.skybox = materialDay;
            directionalLight.transform.rotation = angleDay;
            clock.gameObject.GetComponent<Renderer>().material = materialNoon;
            bliss.gameObject.GetComponent<Renderer>().material = blissDay;
            ToggleText.gameObject.GetComponent<TextMeshPro>().text = "Day!";
            door.GetComponent<DoorOpening>().CallClose();
        }
    }
}
