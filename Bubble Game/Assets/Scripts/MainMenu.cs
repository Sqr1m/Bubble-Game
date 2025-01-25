using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isMuted;

    public GameObject muteButton; // "sound off"
    public GameObject unmuteButton; // "sound on"

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрывается");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        // Сохраняем состояние
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        // Обновляем кнопки
        UpdateSoundButtons();
        Debug.Log(isMuted ? "Звук выключен" : "Звук включен");
    }

    private void Start()
    {
        // Загружаем состояние звука
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        AudioListener.pause = isMuted;

        // Обновляем видимость кнопок
        UpdateSoundButtons();
    }

    private void UpdateSoundButtons()
    {
        muteButton.SetActive(isMuted);
        unmuteButton.SetActive(!isMuted);
    }
}
