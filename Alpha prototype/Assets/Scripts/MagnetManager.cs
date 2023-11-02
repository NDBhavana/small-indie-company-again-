using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetManager : MonoBehaviour
{
     public static int t=0;
     public static int k=0;
     public GameObject attractManager;
     private GameObject attractObj1, attractObj2;
     //public GameObject attract1;
     public float step = 10;
     public List<MagnetNandila> magnets;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (Transform child in transform)
        {
            magnets.Add(child.gameObject.GetComponent<MagnetNandila>());
        }
        attractObj1 = attractManager.gameObject.transform.GetChild(0).gameObject;
        attractObj2 = attractManager.gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if((magnets[0].north == true && magnets[1].north == false) || (magnets[0].north == false && magnets[1].north == true))
        
        {
           
           magnets[0].transform.position = Vector3.MoveTowards(magnets[0].gameObject.transform.position,attractObj1.transform.position,step*Time.deltaTime);
           magnets[1].transform.position = Vector3.MoveTowards(magnets[1].gameObject.transform.position,attractObj2.transform.position,step*Time.deltaTime);

        }
        else
        {
             magnets[0].transform.position = Vector3.MoveTowards(magnets[0].gameObject.transform.position,magnets[0].ogpos,step*Time.deltaTime);
           magnets[1].transform.position = Vector3.MoveTowards(magnets[1].gameObject.transform.position,magnets[1].ogpos,step*Time.deltaTime);
        }
    }
}
