using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] backgroundMusicClips;
    public AudioClip[] sfxClips;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play Background Music
    public void PlayBackgroundMusic(int clipIndex, bool loop = true)
    {
        if (clipIndex >= 0 && clipIndex < backgroundMusicClips.Length)
        {
            backgroundMusicSource.clip = backgroundMusicClips[clipIndex];
            backgroundMusicSource.loop = loop;
            backgroundMusicSource.Play();
        }
    }

    // Play Sound Effect
    public void PlaySFX(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < sfxClips.Length)
        {
            sfxSource.PlayOneShot(sfxClips[clipIndex]);
        }
    }

    // Stop Background Music
    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }
}
