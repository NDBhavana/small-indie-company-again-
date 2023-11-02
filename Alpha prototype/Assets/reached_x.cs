using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class reached_x : MonoBehaviour
{
    public GameObject Tutorial_txt;
    public bool stage1 = true;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial_txt= GameObject.Find("Tutorial text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Follow" && stage1)
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Shoot slime to make it stay");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stay" && stage1)
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Get on top of the slime and jump to get a high jump");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Follow" && stage1)
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Lead the green slime to the X");
        }
    }
}
