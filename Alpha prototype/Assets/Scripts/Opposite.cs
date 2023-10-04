using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opposite : MonoBehaviour
{
    public string oppositeType = "default";

    public void CallOpposite()
    {
        switch (oppositeType)
        {
            case "wall":
                Debug.Log("Hit detected");
                //transform.gameObject.GetComponent<WallScript>().CallFunction();
                //replace WallScript and CallFunction
                break;

            case "fireice":

                break;

            case "enemy2friend":
                this.gameObject.GetComponent<Enemy2friend>().enemy2friendndback();
                break;

            case "default":
                break;
        }
    }
}
