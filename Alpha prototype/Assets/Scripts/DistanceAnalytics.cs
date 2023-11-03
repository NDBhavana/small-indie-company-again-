using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DistanceAnalytics : MonoBehaviour
{
    
    [SerializeField] private string URL;
    private long sessionID;
    private int level;
    private float distanceCovered;

    public void Send(int sceneindex, float totalDistanceForScene)
    {
        // Generate a session ID based on the current timestamp
        sessionID = (long)(Time.time * 1000);

        // Set the level to the sceneindex
        level = sceneindex;

        // Set the distance covered to totalDistanceForScene
        distanceCovered = totalDistanceForScene;

        // Add some debugging logs to check the data before submission
        Debug.Log("Session ID: " + sessionID);
        Debug.Log("Level: " + level);
        Debug.Log("Distance Covered: " + distanceCovered);

        // Call the method to send data to Google Forms
        SendData();
    }

    private void SendData()
    {
        Debug.Log("Sending data to Google Forms...");

        StartCoroutine(Post(sessionID.ToString(), level.ToString(), distanceCovered.ToString()));
    }

    private IEnumerator Post(string sessionID, string level, string distanceCovered)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1542958291", sessionID); // Session ID
        form.AddField("entry.1637838254", level); // Level
        form.AddField("entry.744595498", distanceCovered); // Distance Covered

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Google Form Error: " + www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
