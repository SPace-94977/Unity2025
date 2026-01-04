using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    static int starsDestroyed = 0;

    [SerializeField] int starsToAdvance = 10;
    [SerializeField] int nextSceneID;

    public void StarDestroyed()
    {
        starsDestroyed++;

        if (starsDestroyed == starsToAdvance)
        {
            SceneManager.LoadScene(nextSceneID);
        }
    }
}