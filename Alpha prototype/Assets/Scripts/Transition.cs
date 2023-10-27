using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int sceneindex;
    public int fallscene = 4;
    public GameAnalytics gameAnalytics;
    public GameObject fallscript;

    private void Start()
    {
        gameAnalytics = GameObject.FindObjectOfType<GameAnalytics>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (sceneindex == fallscene && GameObject.Find("PlayerController Variant").GetComponent<FallDamageDetection>().ToggleFallDamage)
        {
            //do nothing

        }
        else if (other.CompareTag("playerbody") && gameAnalytics != null)
        {
            gameAnalytics.DoorOpened(sceneindex);
            SceneManager.LoadScene(sceneindex);
        }
    }
        
            
}