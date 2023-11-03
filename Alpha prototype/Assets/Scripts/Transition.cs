using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;


public class Transition : MonoBehaviour
{
    public int sceneindex;
    public int currentsceneindex;
    public int fallscene = 90004;
    public GameAnalytics gameAnalytics;
    public DistanceAnalytics distanceAnalytics;

    public float totalDistanceForScene; // Total distance for the current scene

    private void Start()
    {
        gameAnalytics = GameObject.FindObjectOfType<GameAnalytics>();
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;

        // Find the DistanceAnalytics script in the scene
        distanceAnalytics = FindObjectOfType<DistanceAnalytics>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.CompareTag("Player") && gameAnalytics != null)
        {
            // Get the total distance for the current scene from the FirstPersonController
            totalDistanceForScene = FirstPersonController.GetTotalDistanceForCurrentScene();
            Debug.Log("###################Distance Covered for Current Scene Before Transition: #####################" + totalDistanceForScene.ToString("F2") + " Units");

            gameAnalytics.DoorOpened(sceneindex);

            // Call the Send() method from the DistanceAnalytics script
            distanceAnalytics.Send(sceneindex, totalDistanceForScene);

            SceneManager.LoadScene(sceneindex);
            Debug.Log("Transitioning to scene " + sceneindex);
        }
    }

        
            
}