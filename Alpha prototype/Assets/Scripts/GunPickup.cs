using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunPickup : MonoBehaviour
{
    public GameObject gun;   
    public GameObject oppwall;   
    public GameObject passage;
    public GameObject tutorial;
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    private void OnTriggerEnter(Collider collision)
    {

        Pick(collision);
        Debug.Log("hitted");
        Destroy(this.gameObject);
        GameObject.Find("Tutorial text").GetComponent<TMP_Text>().SetText("Find a way out");
    }

    private void Pick(Collider collision)
    {
        //enable
        gun.SetActive(true);
        oppwall.SetActive(true);
        passage.SetActive(true);
    }

}
