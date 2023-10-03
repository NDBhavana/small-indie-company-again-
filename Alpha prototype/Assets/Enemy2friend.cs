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
    public bool patrol = true;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        
        
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
        if (shot)
        {
            gameObject.tag = "Friend";
            gameObject.GetComponent<Renderer>().material=friendmaterial;
            patrol = false;
        }
        if (!shot)
        {
            gameObject.tag = "Enemy";
            gameObject.GetComponent<Renderer>().material=enemymaterial;
            patrol = true;
        }
        if (gameObject.tag =="Friend")
        {
            transform.position = Vector3.MoveTowards(transform.position, closest_enemy.transform.position, step);
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
            Destroy(this);
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(this);
        }


    }
   
}

