using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text pointsText;

    Health playerHealth;
    Points playerPoints;

    private void Start()
    {
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
            playerPoints = player.GetComponent<Points>();
        }

        UpdateStats();
    }

    private void Update()
    {
        UpdateStats();
    }

    private void UpdateStats()
    {
        if (playerPoints != null)
            pointsText.text = "POINTS: " + playerPoints.GetPlayerPoints();

        if (playerHealth != null)
            healthText.text = playerHealth.GetHealth() + " / 100";
        
        if (playerHealth.GetHealth() <= 0)
        {
            SceneManager.LoadScene(2);  // Load Game Over scene [ID 2]
        }
    }
}