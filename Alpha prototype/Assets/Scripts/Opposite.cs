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
                WallController wall = GetComponent<WallController>();
                if (wall != null)
                {
                    wall.CallFunction(); // Call the function in WallController.
                }
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
