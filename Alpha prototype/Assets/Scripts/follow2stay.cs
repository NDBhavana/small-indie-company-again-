using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow2stay : MonoBehaviour
{
    public Material followmaterial;
    public Material staymaterial;
    public GameObject player;
    public float range;
    public float speed = 5;
    public float step;
    public GameObject followstaymgr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("playerbody");
        followstaymgr = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if (this.gameObject.tag == "Follow" && Vector3.Distance(transform.position,player.transform.position)> range)
        {
            transform.position= Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        else
        {
            //stop
        }

        
    }

    public void change()
    {
        if (this.gameObject.tag == "Follow")
        {
            this.gameObject.tag = "Stay";
            this.gameObject.GetComponent<Renderer>().material = staymaterial;
        }
        else
        {
            this.gameObject.tag = "Follow";
            this.gameObject.GetComponent<Renderer>().material = followmaterial;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            followstaymgr.GetComponent<followstaymgr>().onblock = true;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            followstaymgr.GetComponent<followstaymgr>().onblock = false;
        }

    }
}
