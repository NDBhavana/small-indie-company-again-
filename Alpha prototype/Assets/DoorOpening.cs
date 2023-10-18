using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject door1, door2;
    private bool doorCheck1 = false, doorCheck2 = false;
    private Vector3 targetPos1, targetPos2;

    private void Start()
    {
        targetPos1 = door1.transform.position;
        targetPos2 = door2.transform.position;
        targetPos1.x += 2.5f;
        targetPos1.y += 2.5f;
        targetPos2.x -= 2.5f;
        targetPos2.y -= 2.5f;
    }

    private void Update()
    {
        if(doorCheck1)
        {
            door1.gameObject.transform.position = Vector3.MoveTowards(door1.transform.position, targetPos1, Time.deltaTime * 3);
        }
        if(doorCheck2)
        {
            door2.gameObject.transform.position = Vector3.MoveTowards(door2.transform.position, targetPos2, Time.deltaTime * 3);
        }
        if(door1.transform.position == targetPos1)
        {
            door1.gameObject.SetActive(false);
        }
        if(door2.transform.position == targetPos2)
        {
            door2.gameObject.SetActive(false);
        }
    }

    public void CallOpen()
    {
        doorCheck1 = true;
        doorCheck2 = true;
    }
}
