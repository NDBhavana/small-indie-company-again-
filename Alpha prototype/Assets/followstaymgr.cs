using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followstaymgr : MonoBehaviour
{
    public List<GameObject> blocks;
    public bool onblock = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            blocks.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
