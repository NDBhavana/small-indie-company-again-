using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gun;   
    public GameObject oppwall;   
    public GameObject passage;   
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    private void OnTriggerEnter(Collider collision)
    {

        Pick(collision);
        Debug.Log("hitted");
        Destroy(this.gameObject);
    }

    private void Pick(Collider collision)
    {
        //enable
        gun.SetActive(true);
        oppwall.SetActive(true);
        passage.SetActive(true);
    }

}
