using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starcollection : MonoBehaviour
{    public bool iscollect = false;
    public bool slime = false;
    private string starName;

    private void Start()
    {  starName = this.gameObject.name;

        if (PlayerPrefs.GetInt(starName) == 1){
            Destroy(gameObject);
        }

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
            starName = this.gameObject.name;
            
            Debug.Log("=================STAR NAME IS==============" + starName);
            PlayerPrefs.SetInt(starName,1);
            //star  star1 star2 star(1) // check if star in playerprefs if yes destroy the gameobject = star, else continue

            Destroy(gameObject);
        }
        else if (other.tag == "Follow" && !slime)
        {
            this.gameObject.transform.parent.GetComponent<Starmanager>().star += 1;
            slime = true;
            starName = this.gameObject.name;
            
            Debug.Log("=================STAR NAME IS==============" + starName);
            PlayerPrefs.SetInt(starName,1);

            Destroy(gameObject);

            // Do nothing
        }
    }

}
