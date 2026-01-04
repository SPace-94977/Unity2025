using UnityEngine;
using TMPro;

public class GameResults : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;

    private void Start()
    {
        pointsText.text = "POINTS: " + GameSession.PlayerPoints;
    }
}