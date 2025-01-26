using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 100f; // Speed of cloud movement in UI space
    public float destroyPosition = -600f; // Y position where the cloud gets destroyed

    private RectTransform cloudRect; // RectTransform of the cloud

    void Start()
    {
        // Get the RectTransform of the cloud
        cloudRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Move the cloud downward in UI space
        cloudRect.anchoredPosition -= new Vector2(0, speed * Time.deltaTime);

        // Check if the cloud has moved past the destroy position
        if (cloudRect.anchoredPosition.y <= destroyPosition)
        {
            // Destroy the cloud GameObject
            Destroy(gameObject);
        }
    }
}
