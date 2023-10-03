using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeGun : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRender;
    public Transform rayOrigin;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)) //hits an object
        {
            //Renders line to point
            lineRender.SetPosition(0, rayOrigin.transform.position);
            Vector3 targetPoint = cam.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
            lineRender.SetPosition(1, hit.point);
            Debug.Log(hit.point);
            

            //Calls Opposite effect function
            if(hit.transform.gameObject.GetComponent<Opposite>() != null)
            {
                hit.transform.gameObject.GetComponent<Opposite>().CallOpposite();
            }

        }
        else //nothing was hit
        {
            lineRender.SetPosition(0, rayOrigin.transform.position);
            lineRender.SetPosition(1, rayOrigin.transform.position + (cam.transform.forward * 100));
        }
        //Starts a delay
        StartCoroutine(ShootLaser());
    }

    IEnumerator ShootLaser()
    {
        lineRender.enabled = true;
        yield return new WaitForSeconds(0.15f);
        lineRender.enabled = false;
    }
}
