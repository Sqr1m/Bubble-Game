using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject[] clouds; // Array of cloud objects
    public float speed = 100f; // Speed of all clouds
    public float destroyPosition = -600f; // Y position where clouds get destroyed

    void Update()
    {
        // Loop through all clouds in the array
        foreach (GameObject cloud in clouds)
        {
            if (cloud != null) // Ensure the cloud exists
            {
                RectTransform cloudRect = cloud.GetComponent<RectTransform>();

                // Move the cloud downward
                cloudRect.anchoredPosition -= new Vector2(0, speed * Time.deltaTime);

                // Destroy the cloud if it moves past the destroy position
                if (cloudRect.anchoredPosition.y <= destroyPosition)
                {
                    Destroy(cloud);
                }
            }
        }
    }
}
