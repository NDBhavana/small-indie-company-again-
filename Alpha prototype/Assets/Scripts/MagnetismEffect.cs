using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismEffect : MonoBehaviour
{
   public Material NpoleMaterial; 
    public Material SpoleMaterial; 

    private Renderer cubeRenderer;
    private bool isNmagnet = true;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        SetInitialMaterial();
    }

    void SetInitialMaterial()
    {
        // Set the initial material to the Npole one
        cubeRenderer.material = isNmagnet ? NpoleMaterial : SpoleMaterial;
        gameObject.tag = isNmagnet ? "Nmagnet" : "Smagnet";
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // You can change the input condition as needed
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.CompareTag("Nmagnet") || hit.transform.CompareTag("Smagnet"))
                {
                    MagnetismEffect magnetismEffect = hit.transform.GetComponent<MagnetismEffect>();
                    if (magnetismEffect != null)
                    {
                        magnetismEffect.ToggleMagnetType();
                    }
                }
            }
        }
    }

    public void ToggleMagnetType()
    {
        isNmagnet = !isNmagnet;
        cubeRenderer.material = isNmagnet ? NpoleMaterial : SpoleMaterial;
        gameObject.tag = isNmagnet ? "Nmagnet" : "Smagnet";
    }
}
