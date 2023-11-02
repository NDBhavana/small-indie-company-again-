using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class checkpoint2 : MonoBehaviour
{
    GameObject Tutorial_txt;
    GameObject checkpoint1;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial_txt = GameObject.Find("Tutorial text");
        checkpoint1 = GameObject.Find("checkpoint 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Follow")
        {
            checkpoint1.GetComponent<reached_checkpoint>().lead = true;
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Shoot slime to make it stay");
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stay")
        {
            checkpoint1.GetComponent<reached_checkpoint>().lead = true;
            Tutorial_txt.GetComponent<TMP_Text>().SetText("The door will stay open now");
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Follow")
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Lead slime to pressure plate");

        }


    }
}
