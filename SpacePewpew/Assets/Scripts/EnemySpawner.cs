using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;

    void Start()
    {
        WaveConfig currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (int i = 0; i < currentWave.GetNumberOfEnemies(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWayPoints()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }
}
