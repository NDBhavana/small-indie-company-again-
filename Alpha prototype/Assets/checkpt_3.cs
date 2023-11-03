using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class checkpt_3 : MonoBehaviour
{
    public static bool reached = false;
    GameObject Tutorial_txt;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial_txt = GameObject.Find("Tutorial text");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag=="playerbody"||other.tag=="Player")
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Go through the door");
        }
    }
   
}
