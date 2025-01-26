using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 1f; // Speed of cloud movement
    public float resetPosition = -6f; // Y position where the cloud resets to the top
    public float startPosition = 10f; // Y position where the cloud starts above the screen

    void Update()
    {
        // Move the cloud downward
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the cloud has moved past the reset position
        if (transform.position.y <= resetPosition)
        {
            // Reset the cloud back to the top
            Vector3 newPosition = transform.position;
            newPosition.y = startPosition;

            // Optionally randomize the X position slightly to avoid visible patterns
            newPosition.x += Random.Range(-1f, 1f);

            transform.position = newPosition;
        }
    }
}
