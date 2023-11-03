using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starmanager : MonoBehaviour
{
    public int star=0;
    public int reqstar=5;
    // Start is called before the first frame update
    public GameObject door;
    

    void Start()
    {
        star = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (star>=reqstar)
        {
             door.GetComponent<DoorOpening>().CallOpen();
        }
        
    }
}
