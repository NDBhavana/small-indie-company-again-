using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WallController : MonoBehaviour
{
    public Material startMaterial; // Reference to the green material.
    public Material stopMaterial; // Reference to the red material.
    private bool isGreen = false; // Indicates if the wall is currently green.
    public TMP_Text txt;
    private Renderer wallRenderer; // Reference to the renderer component.
    private Collider wallCollider; // Reference to the collider attached to the wall.

    private void Start()
    {
        // Get references to the renderer and collider components.
        wallRenderer = GetComponent<Renderer>();
        wallCollider = GetComponent<Collider>();
        
        // Ensure that the collider is initially enabled (red state).
        if (wallCollider != null)
        {
            wallCollider.enabled = true;
        }

        // Set the wall to the initial red material.
        wallRenderer.material = stopMaterial;
        if (this.tag == "Stop")
        {
            isGreen = false;
            wallRenderer.material = stopMaterial;
            txt.text = "STOP";
            if (wallCollider != null)
            {
                wallCollider.isTrigger = false;
            }
        }
        else
        {
            isGreen = true;
            wallRenderer.material = startMaterial;
            txt.text = "GO";
            if (wallCollider != null)
            {
                wallCollider.isTrigger = true;
            }
        }
    }

    public void CallFunction()
    {
        if (isGreen)
        {
            // Change the wall's material back to the red material.
            wallRenderer.material = stopMaterial;
            txt.text = "STOP";
            // Enable the collider to block the player.
            if (wallCollider != null)
            {
                wallCollider.isTrigger = false;
            }

            isGreen = false; // Set the wall to red.
        }
        else
        {
            // Change the wall's material to the green material.
            wallRenderer.material = startMaterial;
            txt.text = "GO";
            // Disable the collider to allow the player to pass through.
            if (wallCollider != null)
            {
                wallCollider.isTrigger = true;
            }

            isGreen = true; // Set the wall to green.
        }
    }
}
