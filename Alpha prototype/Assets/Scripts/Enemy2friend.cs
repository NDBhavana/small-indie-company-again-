using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2friend : MonoBehaviour
{
    public Vector3 startposn;
    public Vector3 endposn;
    public bool shot;
    public int lives = 3;
    public float step = 10;
    public GameObject closest_enemy;
    public float speed = 5;
    public float counter = 0;
    public float timerange = 12;
    public Material friendmaterial;
    public Material enemymaterial;
    public Material enemyplusfriend;
    public bool patrol = true;
    public bool disabled=false;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

        startposn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        counter += Time.deltaTime;
        if (patrol)
        {
            if (counter < timerange / 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, endposn, step);

            }
            if (counter >= timerange / 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, startposn, step);
            }
            if (counter >= timerange)
            {
                counter = 0;
            }
        }
        if (shot && !disabled)
        {
            gameObject.tag = "Friend";
            gameObject.GetComponent<Renderer>().material=friendmaterial;
            patrol = false;
        }
        if (!shot && !disabled)
        {
            gameObject.tag = "Enemy";
            gameObject.GetComponent<Renderer>().material=enemymaterial;
            patrol = true;
        }
        if (disabled)
        {
            patrol = false;
        }
        if (gameObject.tag =="Friend")
        {
            transform.position = Vector3.MoveTowards(transform.position, closest_enemy.transform.position, step);
        }
        if (gameObject.tag == "enemy+friend")
        {
            patrol = false;
            disabled = true;
            gameObject.GetComponent<Renderer>().material = enemyplusfriend;
        }

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            lives -= 1;
            Debug.Log("AAAAAAA");
        }
        if (other.CompareTag("Friend"))
        {
            patrol = false;
            disabled = true;
           
      
            
        }
    

    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Friend") && other.transform.position==this.transform.position)
        {
            patrol = false;
            disabled = true;
            other.gameObject.GetComponent<Enemy2friend>().disabled = true;
            other.gameObject.tag = "enemy+friend";
            this.gameObject.tag = "enemy+friend";


        }
    }
    public void enemy2friendndback()
    {
        if (this.shot)
        {
            this.shot = false;
        }
        else
        {
            this.shot = true;
        }
    }
   
}

