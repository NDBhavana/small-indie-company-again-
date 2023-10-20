using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_fall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerbody" || other.tag == "Player")
        {
            Debug.Log("find god");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
