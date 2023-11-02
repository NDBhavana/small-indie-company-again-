using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public string targetTag = "Moving Box"; 
    private Vector3 pressedPosition; // The position when the plate is pressed
    private Vector3 originalPosition; // The original position of the plate
    public bool isPressed = false; // Boolean to track the state of the pressure plate

    private void Start()
    {
        originalPosition = transform.position; // Store the initial position as the original position
        pressedPosition = originalPosition;
        pressedPosition.y = pressedPosition.y - 0.2f;
    }

    private void Update()
    {
        if (isPressed)
        {
            // Move the pressure plate down to the pressed position
            transform.position = Vector3.Lerp(transform.position, pressedPosition, Time.deltaTime * 10f);
        }
        else
        {
            // Move the pressure plate back to the original position
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * 10f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("work");
        if (other.tag == "Predator"|| other.tag == "Prey"||other.tag=="Player"||other.tag=="Follow"||other.tag=="Stay")
        {
            Debug.Log("hi");
            isPressed = true; // Set the pressure plate as pressed
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Predator" || other.tag == "Prey" || other.tag == "Player"|| other.tag == "Follow" || other.tag == "Stay")
        {
            isPressed = false; // Set the pressure plate as not pressed
        }
    }
}
