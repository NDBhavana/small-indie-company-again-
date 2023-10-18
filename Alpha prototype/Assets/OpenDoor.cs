using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerbody"))
        {
            door.GetComponent<DoorOpening>().CallOpen();
        }
    }
}
