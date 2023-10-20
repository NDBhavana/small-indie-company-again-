using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


using UnityEngine;
using UnityEngine.Networking;
public class GameAnalytics : MonoBehaviour
{[SerializeField] private string analyticsServerURL = "YOUR_ANALYTICS_SERVER_URL";

    private float levelStartTime;
    private string currentLevelName;
    private int temp = 0;
    private int currentLevelIndex = 0; 
    private int totalLevels = 5; 

    private int totalShotsTaken;
    private int shotsThatHit;

    private void Start()
    {
        LoadLevel(currentLevelIndex); 
    }

    public void DoorOpened(int sceneIndex)
    {
        Debug.Log("TESTT");
        SendAnalytics();
        if (sceneIndex == currentLevelIndex + 1)
        {
            currentLevelIndex++;

            if (currentLevelIndex < totalLevels)
            {
                LoadLevel(currentLevelIndex);
            }
            else
            {
                HandleGameCompletion();
            }
        }
    }

    private void LoadLevel(int levelIndex)
    {
        temp += 1;
        currentLevelName = (temp).ToString(); 
        levelStartTime = Time.time; 
        totalShotsTaken = 0; 
        shotsThatHit = 0;
    }

    private void SendAnalytics()
    {
        float timeSpentInLevel = Time.time - levelStartTime;

        // Create a WWWForm to send the data to Google Forms
        WWWForm form = new WWWForm();
        form.AddField("entry.998220439", System.DateTime.Now.Ticks.ToString()); // Session ID
        form.AddField("entry.955054737", currentLevelName); // Level Name
        form.AddField("entry.18421578", timeSpentInLevel.ToString("F2")); // Time Spent
        form.AddField("entry.766404407", totalShotsTaken.ToString()); // Total Shots Taken
        form.AddField("entry.980848063", shotsThatHit.ToString()); // Shots That Hit

        // Send the data to the Google Form
        StartCoroutine(PostData(form));
    }

    private IEnumerator PostData(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(analyticsServerURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Analytics data upload failed: " + www.error);
            }
            else
            {
                Debug.Log("Analytics data uploaded successfully.");
            }
        }
    }

    private void HandleGameCompletion()
    {
        // Handle game completion or display a victory screen
        Debug.Log("Game Completed!");
    }
}