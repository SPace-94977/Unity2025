using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] int points = 0;
    TMP_Text pointsText;

    private void Start()
    {
        // Unity did not allow the object to be dragged in as SerializeField ["Type mismatch"], so it had to be referenced directly in script
        pointsText = GameObject.Find("Points").GetComponent<TMP_Text>();
        UpdatePointsText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PointGiver pointGiver = other.GetComponent<PointGiver>();
        if (pointGiver != null)
        {
            points += pointGiver.GetPoints();
            pointGiver.Hit();
            UpdatePointsText();
        }
    }

    void UpdatePointsText()
    {
        pointsText.text = "POINTS: " + points;
    }
}
