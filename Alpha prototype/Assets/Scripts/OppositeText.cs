using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OppositeText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ToggleText;
    public string oppositeType = "default";
    public GameObject Parent;

    public GameObject Player;
    void Start()
    {
        Parent = this.gameObject.transform.parent.gameObject;
        ToggleText = this.gameObject;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(Player.transform);
        switch (oppositeType)
        {
            case "wall":
                break;

            case "fireice":
                if(Parent.gameObject.tag == "fire"){
                    ToggleText.gameObject.GetComponent<TextMeshPro>().text = "Fire!";
                }else{
                    ToggleText.gameObject.GetComponent<TextMeshPro>().text = "Ice!";
                }
                break;

            case "enemy2friend":
                
                break;

            case "falldamage":

                
                break;

            case "predator2prey":
                
                break;

            case "daynight":
                
                break;
                
            case "default":

                break;
        }
    }
}
