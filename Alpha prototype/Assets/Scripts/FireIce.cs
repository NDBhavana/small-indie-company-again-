using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireIce : MonoBehaviour
{
    public GameObject fireicemanager;
    public Material fire;
    public Material ice;
    public bool istrue = false;
    //public GameObject ToggleText;


    public bool inice = false;
    public bool infire = false;
 

    public void Start()
    {
        fireicemanager = gameObject.transform.parent.gameObject;
    }

    public void colorchange()
    {
        //ToggleText = GameObject.Find("Text");
        if (istrue)
        {
            this.gameObject.GetComponent<Renderer>().material = fire;
            this.gameObject.tag = "fire";
            //this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            //ToggleText.gameObject.GetComponent<TextMeshPro>().text = "Fire!";
            istrue = false;

        }

        else
        {
            this.gameObject.GetComponent<Renderer>().material = ice;
            //transform.Translate(Vector3.forward);
            this.gameObject.tag = "ice";
            //ToggleText.gameObject.GetComponent<TextMeshPro>().text = "Ice!";
            istrue = true;

        }
    }



    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            if(this.CompareTag("ice"))
            {
                fireicemanager.GetComponent<FireIceManager>().inIce=true;
                fireicemanager.GetComponent<FireIceManager>().inFire = false;

                Debug.Log("ice");
            }
            else
            {
                fireicemanager.GetComponent<FireIceManager>().inIce = false;
                fireicemanager.GetComponent<FireIceManager>().inFire = true;
                Debug.Log("fire");
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            fireicemanager.GetComponent<FireIceManager>().inIce = false;
            fireicemanager.GetComponent<FireIceManager>().inFire = false;

        }
    }

}

