using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunPickup : MonoBehaviour
{
    GameObject Tutorial_text;
    public GameObject gun;   
    public GameObject oppwall;   
    public GameObject passage;
    public GameObject tutorial;
    public static bool picked_up=false;
    
  
    void Start()
    {
        Tutorial_text = GameObject.Find("Tutorial text");
    }
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
     
        
        
          
    }

    private void OnTriggerEnter(Collider collision)
    {

        Pick(collision);
        Debug.Log("hitted");
        Destroy(this.gameObject);
        Tutorial_text.GetComponent<TMP_Text>().SetText("Left click to use gun");
        picked_up = true;
    }

    private void Pick(Collider collision)
    {
        //enable
        gun.SetActive(true);
        oppwall.SetActive(true);
        passage.SetActive(true);
    }

}
