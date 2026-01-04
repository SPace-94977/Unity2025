using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] int points = 0;

    private void Start()
    {
        GameSession.PlayerPoints = points;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PointGiver pointGiver = other.GetComponent<PointGiver>();
        if (pointGiver != null)
        {
            points += pointGiver.GetPoints();
            GameSession.PlayerPoints = points;

            pointGiver.Hit();
        }
    }

    public int GetPlayerPoints()
    {
        return points;
    }
}