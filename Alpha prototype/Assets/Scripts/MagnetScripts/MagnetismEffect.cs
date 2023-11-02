using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismEffect : MonoBehaviour
{
  public float repelDistance = 10f;
  
  public Material NpoleMaterial;
  public Material SpoleMaterial;
  
  private Renderer cubeRenderer;
  private bool isNmagnet;

  void Start() {
    cubeRenderer = GetComponent<Renderer>();
    SetInitialMaterial();
  }

  void Update() {
    if (Input.GetButtonDown("Fire1")) {
      RaycastHit hit;
      if (Physics.Raycast(transform.position, transform.forward, out hit)) {
        if (hit.transform.CompareTag("Nmagnet") || hit.transform.CompareTag("Smagnet")) {
          MagnetismEffect otherMagnet = hit.transform.GetComponent<MagnetismEffect>();
          
          if (otherMagnet != null) {
            HandleMagnetism(otherMagnet);
          }
        }
      }
    }
  }

  void HandleMagnetism(MagnetismEffect otherMagnet) {
    float distance = Vector3.Distance(transform.position, otherMagnet.transform.position);
    
    if (distance <= repelDistance) {
      // Magnets are close enough to attract
      Vector3 direction = (otherMagnet.transform.position - transform.position).normalized;
      transform.position += direction * (repelDistance - distance);
      otherMagnet.transform.position -= direction * (repelDistance - distance);
    } 
    else {
      // Magnets are too far and should repel
      ToggleMagnetType();
      otherMagnet.ToggleMagnetType();
      
      if (Mathf.Abs(transform.position.x - otherMagnet.transform.position.x) < 
          Mathf.Abs(transform.position.y - otherMagnet.transform.position.y)) {
        // Repel along x-axis
        Vector3 direction = (otherMagnet.transform.position - transform.position).normalized;
        transform.position += direction * repelDistance;
        otherMagnet.transform.position -= direction * repelDistance; 
      }
      else {
        // Repel along y-axis
        Vector3 direction = (otherMagnet.transform.position - transform.position).normalized;
        transform.position += Vector3.up * direction.y * repelDistance; 
        otherMagnet.transform.position -= Vector3.up * direction.y * repelDistance;
      }
    }
  }

  public void SetInitialMaterial() {
    if (gameObject.CompareTag("Nmagnet")) {
      isNmagnet = true;
      cubeRenderer.material = NpoleMaterial; 
    }
    else if (gameObject.CompareTag("Smagnet")) {
      isNmagnet = false;
      cubeRenderer.material = SpoleMaterial;
    }
  }
  
 public void ToggleMagnetType() {
    isNmagnet = !isNmagnet;
    cubeRenderer.material = isNmagnet ? NpoleMaterial : SpoleMaterial;
    gameObject.tag = isNmagnet ? "Nmagnet" : "Smagnet"; 
  }
}
