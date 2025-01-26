using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudio : MonoBehaviour
{
    [Header("Background Music Clip Index")]
    public int musicClipIndex; // Background music index for this scene

    private void Start()
    {
        // Play the specific background music for this scene
        SoundManager.Instance.PlayBackgroundMusic(musicClipIndex);
    }
}
