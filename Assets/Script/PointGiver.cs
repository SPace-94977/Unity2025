using UnityEngine;

public class PointGiver : MonoBehaviour
{
    [SerializeField] int points = 5;

    public int GetPoints()
    {
        return points;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}