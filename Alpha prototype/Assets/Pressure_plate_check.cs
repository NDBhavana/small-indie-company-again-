using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate_check : MonoBehaviour
{
    public GameObject[] pressure_plates;
    public int plate_no;
    public int presscount;
    public bool opendoor=false;
    // Start is called before the first frame update
    void Start()
    {
        pressure_plates = GameObject.FindGameObjectsWithTag("Pressure_plate");
        plate_no = pressure_plates.Length;
        presscount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject plate in pressure_plates)
        {
            if (plate.GetComponent<PressurePlate>().isPressed)
            {
                presscount += 1;
            }
        }
        
        if (presscount == plate_no)
        {
            opendoor = true;
        }
        
        else { opendoor = false; }

        presscount = 0;

    }
}
