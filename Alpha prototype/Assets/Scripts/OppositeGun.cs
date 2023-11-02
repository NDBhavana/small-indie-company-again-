using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OppositeGun : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRender;
    public Transform rayOrigin;
    GameObject Tutorial_text_l1;
    void Start()
    {
        Tutorial_text_l1 = GameObject.Find("Tutorial text");
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            if (GunPickup.picked_up)//Only for gun tutorial, because gun pickup gets destroyed
            {
                Tutorial_text_l1.GetComponent<TMP_Text>().SetText("Shoot the STOP wall to make it GO(invertable objects light up)");
                GunPickup.picked_up = false;

            }
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
