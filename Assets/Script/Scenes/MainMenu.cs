using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        PlayerStats.hasDied = false;
        SceneManager.LoadScene(1);  // Load Level 1 scene [ID 1]
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}