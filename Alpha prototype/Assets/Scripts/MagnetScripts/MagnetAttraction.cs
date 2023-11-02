using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttraction : MonoBehaviour
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
        // Calculate the distance between the two objects in the x-y plane
        Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 otherPosition = new Vector2(otherMagnet.transform.position.x, otherMagnet.transform.position.y);
        float distance = Vector2.Distance(thisPosition, otherPosition);

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
                MoveTowardOtherMagnet(otherPosition);
            }
        }
    }

    void MoveTowardOtherMagnet(Vector2 otherPosition)
    {
        Vector2 moveDirection = (otherPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.Translate(new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime);

        // Move the other magnet as well
        Vector2 otherMoveDirection = (new Vector2(transform.position.x, transform.position.y) - otherPosition).normalized;
        otherMagnet.transform.Translate(new Vector3(otherMoveDirection.x, otherMoveDirection.y, 0) * moveSpeed * Time.deltaTime);
    }

    bool AreCollidersTouching()
    {
        Bounds thisBounds = thisCollider.bounds;
        Bounds otherBounds = otherCollider.bounds;

        return thisBounds.Intersects(otherBounds);
    }

}
