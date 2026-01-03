using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    int finalPoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Called by Health.cs when the player dies
    public void PlayerDied(int points)
    {
        finalPoints = points;
        SceneManager.LoadScene("GameOverScene");
    }

    // Runs automatically when a new scene loads
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOverScene")
        {
            TMP_Text pointsText = GameObject
                .Find("Points")
                .GetComponent<TMP_Text>();

            pointsText.text = "POINTS: " + finalPoints;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}