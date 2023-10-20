using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject door1, door2;
    private bool doorCheckOpen1 = false, doorCheckOpen2 = false;
    private Vector3 targetPos1, targetPos2;
    private Vector3 ogPos1, ogPos2;

    private void Start()
    {
        ogPos1 = door1.transform.position;
        ogPos2 = door2.transform.position;
        targetPos1 = door1.transform.position;
        targetPos2 = door2.transform.position;

        targetPos1.x += 2.5f;
        targetPos1.y += 2.5f;
        targetPos2.x -= 2.5f;
        targetPos2.y -= 2.5f;
    }

    private void Update()
    {
        if(doorCheckOpen1)
        {
            door1.gameObject.transform.position = Vector3.MoveTowards(door1.transform.position, targetPos1, Time.deltaTime * 3);
        }
        else
        {
            door1.gameObject.transform.position = Vector3.MoveTowards(door1.transform.position, ogPos1, Time.deltaTime * 3);
        }
        if(doorCheckOpen2)
        {
            door2.gameObject.transform.position = Vector3.MoveTowards(door2.transform.position, targetPos2, Time.deltaTime * 3);
        }
        else
        {
            door2.gameObject.transform.position = Vector3.MoveTowards(door2.transform.position, ogPos2, Time.deltaTime * 3);
        }
    }

    public void CallOpen()
    {
        doorCheckOpen1 = true;
        doorCheckOpen2 = true;
    }
    public void CallClose()
    {
        doorCheckOpen1 = false;
        doorCheckOpen2 = false;
    }
}
