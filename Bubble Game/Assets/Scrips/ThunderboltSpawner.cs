using UnityEngine;

public class ThunderboltSpawner : MonoBehaviour
{
    public GameObject thunderboltPrefab; // Assign your thunderbolt prefab
    public float spawnInterval = 1f; // Time between spawns
    public float spawnXMin = -8f; // Minimum X position for spawning
    public float spawnXMax = 8f; // Maximum X position for spawning
    public float thunderboltSpeed = 3f; // Speed of the thunderbolt

    void Start()
    {
        // Start spawning thunderbolts at regular intervals
        InvokeRepeating("SpawnThunderbolt", 0f, spawnInterval);
    }

    void SpawnThunderbolt()
    {
        // Randomize the X position within the screen's width
        float randomX = Random.Range(spawnXMin, spawnXMax);

        // Spawn the thunderbolt at the random X position
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);
        GameObject thunderbolt = Instantiate(thunderboltPrefab, spawnPosition, Quaternion.identity);

        // Make the thunderbolt move upward
        Rigidbody2D rb = thunderbolt.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = thunderbolt.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0; // Disable gravity
        rb.velocity = Vector2.up * thunderboltSpeed;
    }
}
