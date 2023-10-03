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
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            lineRender.SetPosition(0, rayOrigin.transform.position);
            Vector3 targetPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            //lineRender.SetPosition(1, hit.transform.position);
            lineRender.SetPosition(1, rayOrigin.transform.position + (cam.transform.forward * 100));
            

            //Detection function call
            if(hit.transform.gameObject.GetComponent<Opposite>() != null)
            {
                hit.transform.gameObject.GetComponent<Opposite>().CallOpposite();
            }

        }
        else
        {
            lineRender.SetPosition(0, rayOrigin.transform.position);
            lineRender.SetPosition(1, rayOrigin.transform.position + (cam.transform.forward * 100));
        }
        StartCoroutine(ShootLaser());
    }

    IEnumerator ShootLaser()
    {
        lineRender.enabled = true;
        yield return new WaitForSeconds(0.15f);
        lineRender.enabled = false;
    }
}
