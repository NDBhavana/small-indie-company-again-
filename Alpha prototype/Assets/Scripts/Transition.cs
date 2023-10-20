using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int sceneindex;
    public GameAnalytics gameAnalytics;

    private void Start()
    {
        gameAnalytics = GameObject.FindObjectOfType<GameAnalytics>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerbody") && gameAnalytics != null)
        {
            gameAnalytics.DoorOpened(sceneindex);
            SceneManager.LoadScene(sceneindex); 
        }
    }
}