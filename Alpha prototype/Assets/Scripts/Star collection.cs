using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starcollection : MonoBehaviour
{
    public bool iscollect = false;
    public bool slime = false;

    private void Start()
    {
        
       
    }
    private void Update()
    {
        if (slime)
        {
            this.gameObject.transform.parent.GetComponent<Starmanager>().star -= 1;
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("work");
        if (other.tag=="Player")
        {
            Debug.Log("entered player");

            this.gameObject.transform.parent.GetComponent<Starmanager>().star += 1;
           // StarManager starManager = FindObjectOfType<StarManager>();
           //Starmanager.star+=1;
          
            //access star manager and update starcounter += 1
            //delete obj
            Destroy(gameObject);
        }
        else if(other.tag == "Follow" && !slime)
        {
            this.gameObject.transform.parent.GetComponent<Starmanager>().star += 1;
            slime = true;
            Destroy(gameObject);
            //do notthing
        }
        
    }

}
