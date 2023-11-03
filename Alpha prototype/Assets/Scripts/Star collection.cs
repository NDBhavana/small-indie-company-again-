using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starcollection : MonoBehaviour
{
    public bool iscollect = false;
    public bool slime = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (slime)
        {
            this.gameObject.transform.parent.GetComponent<Starmanager>().star -= 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("work");
        if (other.tag == "Player")
        {
            Debug.Log("entered player");

            this.gameObject.transform.parent.GetComponent<Starmanager>().star += 1;
            
            // Access StarAnalytics and send star data
            StarAnalytics starAnalytics = FindObjectOfType<StarAnalytics>();
            if (starAnalytics != null)
            {
                starAnalytics.SendStarData(this.gameObject.name);
            }

            Debug.Log("=================STAR NAME IS==============" + this.gameObject.name);
            Destroy(gameObject);
        }
        else if (other.tag == "Follow" && !slime)
        {
            this.gameObject.transform.parent.GetComponent<Starmanager>().star += 1;
            slime = true;

            // Access StarAnalytics and send star data
            StarAnalytics starAnalytics = FindObjectOfType<StarAnalytics>();
            if (starAnalytics != null)
            {
                starAnalytics.SendStarData(this.gameObject.name);
            }

            Debug.Log("=================STAR NAME IS==============" + this.gameObject.name);
            
            Destroy(gameObject);


            // Do nothing
        }
    }

}
