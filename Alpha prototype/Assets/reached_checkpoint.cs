using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class reached_checkpoint : MonoBehaviour
{
    public GameObject Tutorial_txt;
    public bool lead = false;
    public GameObject x_point;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial_txt = GameObject.Find("Tutorial text");
        x_point = GameObject.Find("X");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("playerbody") && !lead)
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Shoot slime to lead it to pressure plate");
            x_point.GetComponent<reached_x>().stage1 = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerbody") && !lead)
        {
            
            x_point.GetComponent<reached_x>().stage1 = true;
        }
    }

}
