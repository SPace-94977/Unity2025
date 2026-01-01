using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    TMP_Text healthText;

    private void Start()
    {
        // Same system as Points display, finding Health object of type TMP_Text
        healthText = GameObject.Find("Health").GetComponent<TMP_Text>();
        UpdateHealthText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;

        UpdateHealthText();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealthText()
    {
        healthText.text = health + " / 100";
    }
}