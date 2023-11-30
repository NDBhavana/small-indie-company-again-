using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StarAnalytics : MonoBehaviour
{[SerializeField] private string URL;
    private long sessionID;
    private int level;

    private void Awake()
    {
        // Generate a session ID based on the current timestamp when the script is created
        sessionID = (long)(Time.time * 1000);
        level = SceneManager.GetActiveScene().buildIndex; 
    }

    public void SendStarData(string starName)
    {
        // Add some debugging logs to check the data before submission
        Debug.Log("Session ID: " + sessionID);
        Debug.Log("Level: " + level);
        Debug.Log("Star Name: " + starName);

        // Call the method to send data to Google Forms
        SendData(sessionID.ToString(), level.ToString(), starName);
    }

    private void SendData(string sessionID, string level, string starName)
    {
        Debug.Log("Sending star data to Google Forms...");

        StartCoroutine(Post(sessionID, level, starName));
    }

    private IEnumerator Post(string sessionID, string level, string starName)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.354171230", sessionID); // Session ID
        form.AddField("entry.1212972671", level); // Level
        form.AddField("entry.1551089213", starName); // Star Name

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


 