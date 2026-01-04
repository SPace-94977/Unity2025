using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    static int starsDestroyed = 0;

    [SerializeField] int starsToAdvance = 10;
    [SerializeField] Scene nextScene;

    public void StarCollected()
    {
        starsDestroyed++;

        if (starsDestroyed == starsToAdvance)
        {
            SceneManager.LoadScene(nextScene.name);
        }
    }
}