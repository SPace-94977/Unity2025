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
        NextLevel nextLevel = GetComponent<NextLevel>();
        if (nextLevel != null)
        {
            nextLevel.StarCollected();
        }

        if (collectSFX != null)
        {
            AudioSource.PlayClipAtPoint(collectSFX, Camera.main.transform.position, 0.25f);
        }
        
        Destroy(gameObject);
    }
}