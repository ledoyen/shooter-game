using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;

    int waveIndex = 0;
    bool waveInProgress = false;

    void Update()
    {
        if (!waveInProgress)
        {
            waveInProgress = true;
            StartCoroutine(LaunchWave());
        }
    }

    IEnumerator LaunchWave()
    {
        WaveConfig wave = waves[waveIndex];
        int enemiesLeft = wave.GetNumberOfEnemies();
        for (int i = 0; i < wave.GetNumberOfEnemies(); i++)
        {
            GameObject enemy = Instantiate(wave.GetEnemyPrefab());
            // TODO inject waypoints in enemy.GetComponent<EnemyPathing>()
            EnemyPathing enemyPathing = enemy.GetComponent<EnemyPathing>();
            enemyPathing.SetOnDestroyCallback(() => enemiesLeft--);
            enemyPathing.waveConfig = wave;
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }

        do
        {
            yield return new WaitForSeconds(0.5F);
        } while (enemiesLeft > 0);
        waveIndex = (waveIndex + 1) % waves.Count;
        waveInProgress = false;
    }
}
