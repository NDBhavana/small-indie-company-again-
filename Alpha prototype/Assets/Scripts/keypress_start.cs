using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypress_start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            //play level screen
            Debug.Log("Start");
        }
    }
}
