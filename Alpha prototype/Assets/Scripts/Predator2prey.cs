using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator2prey : MonoBehaviour
{
    public bool predator;
    public GameObject gameObject;
    public Material predatormaterial;
    public Material preymaterial;
    public Vector3 startposn;
    public Vector3 endposn;
    public float range=10;//distance prey keeps from the predator
    public Vector3 newposn;
    public bool xmvmt=true;
    public GameObject player;
    public float speed = 5;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("playerbody");
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if (predator)
        {
            this.gameObject.tag = "Predator";
            this.gameObject.GetComponent<Renderer>().material = predatormaterial;

            newposn = Vector3.Distance(player.transform.position, startposn) < Vector3.Distance(player.transform.position, endposn) ? startposn : endposn;
            transform.position = Vector3.MoveTowards(transform.position, newposn, step);



            //need to add code that prevents cube from moving out of fixed path

            transform.position = Vector3.MoveTowards(transform.position, newposn,step);

        }
        if (!predator)
        {
            this.gameObject.tag = "Prey";
            this.gameObject.GetComponent<Renderer>().material = preymaterial;
            if (xmvmt)
            {
                newposn = new Vector3(player.transform.position.x , transform.position.y, transform.position.z);
            }
            else
            {
                newposn = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            }
           
                newposn = Vector3.Distance(player.transform.position, startposn) > Vector3.Distance(player.transform.position, endposn) ? startposn : endposn;
                transform.position = Vector3.MoveTowards(transform.position, newposn, step);

            
        }


    }
    public void predator2prey()
    {
        if (this.predator)
        {
            this.predator = false;
        }
        else
        {
            this.predator = true;
        }
    }
}

