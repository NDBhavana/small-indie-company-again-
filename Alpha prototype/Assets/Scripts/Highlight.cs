using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        HighlightObject();  
    }

    private void HighlightObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)) //hits an object
        {
            //Highlight the object
        switch (hit.transform.tag)
        {
            case "fire":
                
                break;

            case "ice":
                
                break;

            case "Untagged":
                
                break;
            case "falldamage":

               
                break;
            case "predator2prey":
                
                break;
            case "daynight":
                
                break;
            case "follow2stay":
                
                break;
            case "default":
                break;
        }
        }
        
    }

}
