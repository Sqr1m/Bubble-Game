using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void SwitchToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}