using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypress_levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //play level 1
            Debug.Log("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //play level 2
            Debug.Log("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //play level 3
            Debug.Log("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //play level 4
            Debug.Log("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //play level 5
            Debug.Log("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //play level 6
            Debug.Log("Level 1");
        }

    }
}
