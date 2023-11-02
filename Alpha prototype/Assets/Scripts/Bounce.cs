using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 500f; // Adjust the force as needed
    private Rigidbody rb;
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hiiii");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("helloooo");
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce);
            
        }

    }
}
