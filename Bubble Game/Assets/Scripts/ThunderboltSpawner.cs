using UnityEngine;

public class ThunderboltSpawner : MonoBehaviour
{
    [Header("Thunderbolt Settings")]
    public GameObject[] thunderboltPrefabs; // Array of thunderbolt prefabs
    public float spawnInterval = 1f; // Time between spawns
    public float spawnXMin = -8f; // Minimum X position for spawning
    public float spawnXMax = 8f; // Maximum X position for spawning
    public float spawnY = -6f; // The Y position where thunderbolts spawn (just off-screen)

    [Header("Movement Settings")]
    public float thunderboltSpeed = 3f; // Speed of the thunderbolt
    public float angleRange = 15f; // Max angle variation in degrees

    void Start()
    {
        // Start spawning thunderbolts at regular intervals
        InvokeRepeating("SpawnThunderbolt", 0f, spawnInterval);
    }

    void SpawnThunderbolt()
    {
        if (thunderboltPrefabs.Length == 0) return; // Ensure there are thunderbolt prefabs assigned

        // Randomize the X position within the screen's width
        float randomX = Random.Range(spawnXMin, spawnXMax);

        // Choose a random thunderbolt prefab
        int randomIndex = Random.Range(0, thunderboltPrefabs.Length);
        GameObject thunderboltPrefab = thunderboltPrefabs[randomIndex];

        // Spawn the thunderbolt just below the screen
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        GameObject thunderbolt = Instantiate(thunderboltPrefab, spawnPosition, Quaternion.identity);

        // Add Rigidbody2D if it doesn't exist
        Rigidbody2D rb = thunderbolt.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = thunderbolt.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0; // Disable gravity

        // Randomize the angle of movement
        float randomAngle = Random.Range(-angleRange, angleRange); // Angle variation in degrees
        Vector2 direction = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;

        // Set the velocity of the thunderbolt
        rb.velocity = direction * thunderboltSpeed;

        // Adjust the rotation to face the movement direction
        RotateThunderboltToDirection(thunderbolt, direction);
    }

    void RotateThunderboltToDirection(GameObject thunderbolt, Vector2 direction)
    {
        // Calculate the angle between the thunderbolt's movement and the upward direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the thunderbolt
        thunderbolt.transform.rotation = Quaternion.Euler(0, 0, angle - 90f); // Subtract 90 to align the sprite properly
    }
}
