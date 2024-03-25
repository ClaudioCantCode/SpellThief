using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float backgroundSpeed = 1f; // Adjust this value to control the speed of the background movement
    public float resetPositionX = -29.7f; // X position at which the background resets

    void Update()
    {
        // Move the background horizontally
        float moveAmount = backgroundSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * moveAmount);

        // Check if the background has moved beyond the reset position
        if (transform.position.x <= resetPositionX)
        {
            // Reset the background position to its initial position
            ResetBackgroundPosition();
        }
    }

    // Function to reset the background position
    void ResetBackgroundPosition()
    {
        Vector3 initialPosition = transform.position;
        initialPosition.x = 28.72f; // Set the X position to the initial position
        transform.position = initialPosition;
    }
}
