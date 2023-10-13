using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIce : MonoBehaviour
{
    public Material fire;
    public Material ice;
    private bool istrue = false;
   
    public bool inice = false;
    public bool infire = false;
    public void colorchange()
    {
        if(istrue)
        {
            this.gameObject.GetComponent<Renderer>().material = fire;
            this.gameObject.tag = "fire";
            //this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);

            istrue = false;
             
                        
                        


        }

        else
        {
            this.gameObject.GetComponent<Renderer>().material = ice;
            //transform.Translate(Vector3.forward);
            this.gameObject.tag = "ice";
            istrue = true;

        }
    }
    void Update()
    {
       
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            Debug.Log("OW");
            
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            if(this.CompareTag("ice"))
            {
                inice = true;
                infire = false;
                Debug.Log("ice");
            }
            else
            {
                inice = false;
                infire = true;
                Debug.Log("fire");
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            if (this.CompareTag("ice"))
            {
                inice = false;
                infire = false;
             
            }
            else
            {
                inice = false;
                infire = false;
               
            }

        }
    }

}

