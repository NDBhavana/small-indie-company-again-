using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondPlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Tutorial_txt;

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
        if (other.tag == "Player")
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Collect your first STAR to go forward!");
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("");
        }

    }
}
