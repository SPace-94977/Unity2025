using UnityEngine;

public class PointGiver : MonoBehaviour
{
    [SerializeField] int points = 5;
    [SerializeField] AudioClip collectSFX;

    public int GetPoints()
    {
        return points;
    }

    public void Hit()
    {
        if (collectSFX != null)
        {
            AudioSource.PlayClipAtPoint(collectSFX, Camera.main.transform.position, 0.25f);
        }
        
        Destroy(gameObject);
    }
}