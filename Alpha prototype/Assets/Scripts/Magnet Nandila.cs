using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetNandila : MonoBehaviour
{
   
    public Material Npole;
    public Material Spole;
    public bool north = false;
    public Vector3 ogpos;
    

    // Start is called before the first frame update
    void Start()
    {
        ogpos =  transform.position;
    }

    // Update is called once per frame
   

    public void colorchangeM()
    {
        
        if (north)
        {
            this.gameObject.GetComponent<Renderer>().material = Npole;
           
            //this.gameObject.tag = "Npole";
            //cp=this.gameObject.transform.position;
            MagnetManager.t=1;
        
            north = false;
           

        }

        else
        {
            this.gameObject.GetComponent<Renderer>().material = Spole;
    
           // this.gameObject.tag = "Spole";
            
            north = true;
            MagnetManager.k=1;
            

        }
    }

     void Update()
    {

        
    }



}
