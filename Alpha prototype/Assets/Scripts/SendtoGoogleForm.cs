using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;


public class SendtoGoogleForm : MonoBehaviour
{
    [SerializeField] private string URL;
    private long _sessionID;
    private int _testInt;
    private bool _testBool;
    private float _testFloat;

    // Start is called before the first frame update
    private void Awake() {
        _sessionID = DateTime.Now.Ticks;
        Send();
    }

    public void Send()  {
        _testInt = UnityEngine.Random.Range(0, 101);
        _testBool = true;
        _testFloat = UnityEngine.Random.Range(0.0f, 10.0f);
        StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString(),
        _testBool.ToString(), _testFloat.ToString()));
    }

    private IEnumerator Post(string sessionID, string testInt, string
    testBool, string testFloat)
    {
    // Create the form and enter responses
    WWWForm form = new WWWForm();
    form.AddField("entry.1824374629", sessionID);
    form.AddField("entry.1200875928", testInt);
    form.AddField("entry.1442245994", testBool);
    form.AddField("entry.2572269", testFloat);
    // Send responses and verify result
    using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
            {
            Debug.Log(www.error);
            }
            else
            {
            Debug.Log("Form upload complete!");
            }
        }
    }

}
