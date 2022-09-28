using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetwenWaves = 0f;
    [SerializeField] bool isLooping = true;

    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnWaveEnemies());
    }

    public WaveConfigSO GetCurrentWave()   
    {
        return currentWave;
    }

    private IEnumerator SpawnWaveEnemies() 
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemysCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWayPoint().position,
                            Quaternion.Euler(0, 0, 180),
                            transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }
            yield return new WaitForSeconds(timeBetwenWaves);
        }
        while (isLooping);
        
        
    }

}
