using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDamageDetection : MonoBehaviour
{
    public bool ToggleFallDamage = true;
    public GameObject transitscript;
    private void OnTriggerEnter(Collider other) {
        if(ToggleFallDamage)
        {
            if(other.gameObject.tag == "playerbody" || other.gameObject.tag =="Player"){
                //Debug.Log("My name is Malenia!");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
/*
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("My name is Malenia!");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("My name is Malenia!");
        }
    }
    */

}
