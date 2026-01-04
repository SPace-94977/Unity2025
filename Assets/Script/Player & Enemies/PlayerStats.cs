using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] GameObject explosionPrefab;

    Health playerHealth;
    Points playerPoints;
    Vector3 playerPos;
    bool hasDied = false;

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
        {
            pointsText.text = "POINTS: " + playerPoints.GetPlayerPoints();
        }
            
        if (playerHealth != null)
        {
            healthText.text = playerHealth.GetHealth() + " / 100";
        }
        
        if (player != null)
        {
            playerPos = player.transform.position;
        }

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (player == null && hasDied == false)
        {
            hasDied = true;

            if (explosionPrefab != null)
            {
                Instantiate(
                    explosionPrefab,
                    playerPos,
                    Quaternion.identity
                );
            }
        }
    }
}