using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 100f; // Speed of cloud movement in UI space
    public float resetPosition = -600f; // Y position where the cloud resets to the top
    public float startPosition = 600f; // Y position where the cloud starts above the screen
    public RectTransform canvasRect; // Reference to the canvas RectTransform
    private RectTransform cloudRect; // RectTransform of the cloud
    private float initialX; // Store the initial X position

    void Start()
    {
        // Get the RectTransform of the cloud
        cloudRect = GetComponent<RectTransform>();

        // Save the initial X position to maintain consistency
        initialX = cloudRect.anchoredPosition.x;
    }

    void Update()
    {
        // Move the cloud downward in UI space
        cloudRect.anchoredPosition -= new Vector2(0, speed * Time.deltaTime);

        // Check if the cloud has moved past the reset position
        if (cloudRect.anchoredPosition.y <= resetPosition)
        {
            // Reset the cloud back to the top
            Vector2 newPosition = cloudRect.anchoredPosition;
            newPosition.y = startPosition;

            // Use the stored initial X position to keep it consistent
            newPosition.x = initialX;

            // Apply the new position
            cloudRect.anchoredPosition = newPosition;
        }
    }
}
