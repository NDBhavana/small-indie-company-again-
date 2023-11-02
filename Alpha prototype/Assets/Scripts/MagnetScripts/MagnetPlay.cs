using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPlay : MonoBehaviour
{
    public string otherMagnetTag = "Smagnet"; // Tag of the other magnet cube
    public float moveSpeed = 5.0f; // Adjust the movement speed as needed

    private GameObject otherMagnet;
    private Collider thisCollider;
    private Collider otherCollider;

    private bool isMoving = true;

    // Maximum allowed distance for attraction
    private float maxDistance = 10.0f;

    void Start()
    {
        otherMagnet = GameObject.FindGameObjectWithTag(otherMagnetTag);

        if (otherMagnet == null)
        {
            Debug.LogError("No object with tag " + otherMagnetTag + " found.");
            return;
        }

        thisCollider = GetComponent<Collider>();
        otherCollider = otherMagnet.GetComponent<Collider>();
    }

    void Update()
    {
        // Calculate the distance between the two objects
        float distance = Vector3.Distance(transform.position, otherMagnet.transform.position);

        // Check if the distance is within the maximum allowed distance
        if (distance <= maxDistance)
        {
            if (!isMoving)
            {
                return;
            }

            if (AreCollidersTouching())
            {
                isMoving = false;
            }
            else
            {
                MoveTowardOtherMagnet();
            }
        }
    }

    void MoveTowardOtherMagnet()
    {
        Vector3 moveDirection = (otherMagnet.transform.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Move the other magnet as well
        Vector3 otherMoveDirection = (transform.position - otherMagnet.transform.position).normalized;
        otherMagnet.transform.Translate(otherMoveDirection * moveSpeed * Time.deltaTime);
    }

    bool AreCollidersTouching()
    {
        Bounds thisBounds = thisCollider.bounds;
        Bounds otherBounds = otherCollider.bounds;

        return thisBounds.Intersects(otherBounds);
    }
}
