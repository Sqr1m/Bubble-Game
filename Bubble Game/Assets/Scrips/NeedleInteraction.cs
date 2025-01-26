using UnityEngine;
using UnityEngine.SceneManagement; // For scene transitions

public class NeedleInteraction : MonoBehaviour
{
    [Header("Scene Transition")]
    public string endingSceneName = "EndingComicScene"; // Replace with your ending scene's name

    [Header("Effects")]
    public GameObject bubblePopEffect; // Assign the particle prefab in the Inspector
    public AudioClip bubblePopSound; // Assign a sound effect for the bubble pop
    public float soundVolume = 1.0f; // Volume of the bubble pop sound

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component dynamically if one doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the Player interacts with the needle
        if (other.CompareTag("Player")) // Ensure the player GameObject is tagged "Player"
        {
            // Instantiate the bubble pop effect at the player's position
            if (bubblePopEffect != null)
            {
                // Create the particle system instance
                GameObject effect = Instantiate(bubblePopEffect, other.transform.position, Quaternion.identity);

                // Explicitly play the particle system
                ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }

                // Destroy the particle system after it finishes playing
                Destroy(effect, ps.main.duration);
            }

            // Play the bubble pop sound
            if (bubblePopSound != null)
            {
                audioSource.PlayOneShot(bubblePopSound, soundVolume);
            }

            // Destroy the player's GameObject (simulate the bubble popping)
            Destroy(other.gameObject);

            // Transition to the ending comic scene
            SceneManager.LoadScene(endingSceneName);
        }
    }
}
