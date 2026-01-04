using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    private void Start()
    {
        GameSession.PlayerHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            GameSession.PlayerHealth = health;
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}