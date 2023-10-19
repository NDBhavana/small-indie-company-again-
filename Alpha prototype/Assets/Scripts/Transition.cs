using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int sceneindex;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            SceneManager.LoadScene(sceneindex);
        }
    }
}
