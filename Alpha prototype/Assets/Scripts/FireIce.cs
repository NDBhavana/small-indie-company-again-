using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIce : MonoBehaviour
{
    public Material fire;
    public Material ice;
    private bool istrue = false;

    public void colorchange()
    {
        if(istrue)
        {
            this.gameObject.GetComponent<Renderer>().material = fire;
            istrue = false;
        }

        else
        {
            this.gameObject.GetComponent<Renderer>().material = ice;
            istrue = true;

        }
    }
}
