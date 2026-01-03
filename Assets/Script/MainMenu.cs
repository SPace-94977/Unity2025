using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);  // Load Level scene [ID 1]
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}