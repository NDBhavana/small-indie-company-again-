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

                if (GameObject.Find("Floor").GetComponent<FallDamageDetection>().ToggleFallDamage)
                {
                    this.gameObject.GetComponent<TextMeshPro>().text = "There is No Fall Damage!";
                    GameObject.Find("Floor").GetComponent<FallDamageDetection>().ToggleFallDamage = false;
                }
                else
                {
                    this.gameObject.GetComponent<TextMeshPro>().text = "There is Fall Damage!";
                    GameObject.Find("Floor").GetComponent<FallDamageDetection>().ToggleFallDamage = true;
                }
                break;
            case "predator2prey":
                this.gameObject.GetComponent<Predator2prey>().predator2prey();
                break;
            case "daynight":
                //this.gameObject.GetComponent<DayNightCycle>().ChangeTime();
                this.gameObject.GetComponentInParent<DayNightCycle>().ChangeTime();
                break;
            case "follow2stay":
                //code for follow 2 stay
                this.gameObject.GetComponent<follow2stay>().change();
                break;
            case "MagnetismEffect":
                //code for Magnetism effect
                this.gameObject.GetComponent<MagnetNandila>().colorchangeM();
                break;
            case "default":
                break;
        }
    }
}
