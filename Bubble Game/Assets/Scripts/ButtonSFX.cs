using UnityEngine;
using UnityEngine.UI;

public class ButtonSFX : MonoBehaviour
{
    [Header("SFX Clip Index for Button")]
    public int sfxClipIndex; // Index of the SFX in the SoundManager

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => PlayButtonSFX());
        }
    }

    private void PlayButtonSFX()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySFX(sfxClipIndex);
        }
    }
}