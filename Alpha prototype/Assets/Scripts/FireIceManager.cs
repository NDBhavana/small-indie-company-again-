using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIceManager : MonoBehaviour
{
    public List<GameObject> fireices;
    public bool inFire = false;
    public bool inIce = false;
    void Start()
    {
        foreach (Transform child in transform)
        {
            fireices.Add(child.gameObject);
        }
    }

    void Update()
    {
        
    }
}
