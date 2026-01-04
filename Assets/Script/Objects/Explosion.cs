using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] Sprite[] explosionFrames;
    [SerializeField] float animationSpeed = 0.1f;

    [Header("SFX")]
    [SerializeField] AudioClip explosionSFX;

    SpriteRenderer spriteRenderer;
    int currentFrame = 0;
    float timer = 0f;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (explosionSFX != null)
        {
            AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, 0.2f);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= animationSpeed)
        {
            timer = 0f;
            currentFrame++;
            
            if (currentFrame == explosionFrames.Length)
            {
                Destroy(gameObject);

                if (PlayerStats.hasDied)
                {
                    SceneManager.LoadScene(3);  // Game Over Scene [ID 3]
                }
            }
            else
            {
                spriteRenderer.sprite = explosionFrames[currentFrame];
            }
        }
    }
}