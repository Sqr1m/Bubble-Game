using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        Debug.Log("????? ?? ????"); 
        Application.Quit(); 
    }
}
