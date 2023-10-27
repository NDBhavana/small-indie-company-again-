using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int sceneindex;
    public int currentsceneindex;
    public int fallscene = 4;
    public GameAnalytics gameAnalytics;
    

    private void Start()
    {
        gameAnalytics = GameObject.FindObjectOfType<GameAnalytics>();
        currentsceneindex= SceneManager.GetActiveScene().buildIndex;

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        //if (sceneindex == fallscene+1 && GameObject.Find("PlayerController Variant").GetComponent<FallDamageDetection>().ToggleFallDamage)
        //{
            //do nothing

        //}
        if (other.CompareTag("playerbody") && gameAnalytics != null)
        {
            gameAnalytics.DoorOpened(sceneindex);
            SceneManager.LoadScene(sceneindex);
            Debug.Log("transit");
        }
    }
    
        
            
}