using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetRepulsion : MonoBehaviour
{
    public string otherMagnetTag = "Smagnet"; // Tag of the other magnet cube
    public float moveSpeed = 5.0f; // Adjust the movement speed as needed

    private GameObject otherMagnet;
    private Collider thisCollider;
    private Collider otherCollider;

    private bool isMoving = true;

    // Maximum allowed distance for repulsion
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

    void FixedUpdate()
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
                MoveAwayFromOtherMagnet(otherPosition);
            }
        }
    }

    void MoveAwayFromOtherMagnet(Vector2 otherPosition)
    {
        Vector2 moveDirection = (new Vector2(transform.position.x, transform.position.y) - otherPosition).normalized;
        transform.Translate(new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.fixedDeltaTime);

        // Move the other magnet as well
        Vector2 otherMoveDirection = (otherPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        otherMagnet.transform.Translate(new Vector3(otherMoveDirection.x, otherMoveDirection.y, 0) * moveSpeed * Time.fixedDeltaTime);
    }

    bool AreCollidersTouching()
    {
        Bounds thisBounds = thisCollider.bounds;
        Bounds otherBounds = otherCollider.bounds;

        return thisBounds.Intersects(otherBounds);
    }
}
