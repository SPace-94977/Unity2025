using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] WaveConfig[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping;
    WaveConfig currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {   
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform);

                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
                }  
                yield return new WaitForSeconds(timeBetweenWaves);
            }  

        } while (isLooping);
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
}
