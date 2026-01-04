using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] int damage = 10;

    [Header("Destruction")]
    public bool destroyOnCollision;
    [SerializeField] GameObject explosionPrefab;

    Vector3 dealerPos;
    
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (destroyOnCollision)
        {
            dealerPos = gameObject.transform.position;
            if (explosionPrefab != null)
            {
                Instantiate(
                    explosionPrefab,
                    dealerPos,
                    Quaternion.identity
                );
            }

            Destroy(gameObject);
        }
    }
}