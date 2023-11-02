using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacandAntiVac : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        other.transform.position = Vector3.MoveTowards(other.transform.position, this.transform.position, Time.deltaTime * 1000);
    }

}
