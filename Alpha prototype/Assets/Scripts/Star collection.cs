using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starcollection : MonoBehaviour
{
    public bool iscollect = false;
    public GameObject otherObject;

     void OnTriggerEnter(Collider other)
    {
        Debug.Log("work");
        if (other.tag=="Player")
        {
            Debug.Log("entered player");

            otherObject.GetComponent<Starmanager>().star+=1;
           // StarManager starManager = FindObjectOfType<StarManager>();
           //Starmanager.star+=1;
          
            //access star manager and update starcounter += 1
            //delete obj
            Destroy(gameObject);
        }
    }

}
