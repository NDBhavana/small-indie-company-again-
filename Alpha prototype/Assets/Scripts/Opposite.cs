using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
                this.gameObject.GetComponent<FireIce>().colorchange();
                break;

            case "enemy2friend":
                this.gameObject.GetComponent<Enemy2friend>().enemy2friendndback();
                break;
            case "falldamage":
                this.gameObject.GetComponent<TextMeshPro>().text="NO FALL DAMAGE";
                GameObject.Find("Floor").GetComponent<FallDamageDetection>().ToggleFallDamage = !(GameObject.Find("Floor").GetComponent<FallDamageDetection>().ToggleFallDamage);
                break;
            case "default":
                break;
        }
    }
}
