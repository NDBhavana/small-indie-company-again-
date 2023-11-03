using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class checkpoints : MonoBehaviour
{
    GameObject Spole;
    GameObject Tutorial_txt;
    GameObject Npole;
    bool ch1 = false;
    bool ch2 = false;
    public bool ch3 = false;
    bool npole = false;
    bool spole = false;
    // Start is called before the first frame update
    void Start()
    {
        Spole = GameObject.Find("Spole");
        Npole = GameObject.Find("Npole");
        Tutorial_txt = GameObject.Find("Tutorial text");
    }

    // Update is called once per frame
    void Update()
    {   spole = Spole.GetComponent<MagnetNandila>().north;
        npole = Npole.GetComponent<MagnetNandila>().north;
        if (( spole && !npole)|| (!spole && npole))

        {
            ch1 = true;
        }
            
        if(ch1 && !ch2 && !ch3)
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Get on the platform and shoot it to go up");
            ch2 = true;
        }
        else if(ch1 && ch2 && !ch3)
        {
            ch3 = checkpt_3.reached;
            
        }
        else if(ch1 && ch2 && ch3)
        {
            Tutorial_txt.GetComponent<TMP_Text>().SetText("Go through the door to the next level");
        }
       
    }
}
