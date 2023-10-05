using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamageDetection : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Death"){
            Debug.Log("My name is Malenia!");
        }
    }

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
    

}
