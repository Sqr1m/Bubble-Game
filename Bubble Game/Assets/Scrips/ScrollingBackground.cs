using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public float scrollSpeed = 2f; // Speed at which the background scrolls
    public float backgroundHeight = 10f; // The height of the background in world units

    void Update()
    {
        // Move the background down every frame
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Check if the background has moved completely off-screen
        if (transform.position.y <= -backgroundHeight)
        {
            // Reposition it back to the top
            Vector3 newPosition = transform.position;
            newPosition.y += 2 * backgroundHeight; // Move it up by twice its height
            transform.position = newPosition;
        }
    }
}
