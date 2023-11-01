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
    public float rightbound;
    public float leftbound;
    public float frontbound;
    public float backbound;
    public float fixed_y;
    public float x_pos;
    public float z_pos;
    Vector3 newpos;
    Vector3 ppos;
    public bool out_of_bounds = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("playerbody");
        followstaymgr = GameObject.Find("follow-stay mgr"); 

        fixed_y = transform.position.y;
        Debug.Log(fixed_y);
}

// Update is called once per frame
void Update()
    {
        step = speed * Time.deltaTime;
        x_pos = transform.position.x;//local position is only used for checks because it makes the check easier, rest we use position relative to whatever scale the object is using
        
        out_of_bounds=false;
        
        ppos = player.transform.position;
       

        if (this.gameObject.tag == "Follow" && Vector3.Distance(transform.position, new Vector3(ppos.x, fixed_y, ppos.z)) > range)
        {
           
            newpos= Vector3.MoveTowards(transform.position, new Vector3(ppos.x,fixed_y,ppos.z), step);
            if ( newpos.x> rightbound)
            {

                out_of_bounds = true;
                newpos.x = rightbound;
            }
            else if (newpos.x < leftbound)
            {

                out_of_bounds = true;
                newpos.x = leftbound;
            }


            
            if (newpos.z > frontbound)
            {

                out_of_bounds = true;
                newpos.z= frontbound;
            }
            else if (newpos.z < backbound)
            {

                out_of_bounds = true;
                newpos.z = backbound;
            }
            transform.position = newpos;
        }
        else
        {
            //stop
        }

        
    }

    public void change()
    {
        Material[] materials = this.gameObject.GetComponent<Renderer>().materials;
        
        if (this.gameObject.tag == "Follow")
        {
            materials[1] = staymaterial;
            this.gameObject.tag = "Stay";
            this.gameObject.GetComponent<Renderer>().materials = materials;
            //this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = staymaterial;
        }
        else
        {
            materials[1] = followmaterial;
            this.gameObject.tag = "Follow";
            this.gameObject.GetComponent<Renderer>().materials = materials;
            //this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = followmaterial;
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
