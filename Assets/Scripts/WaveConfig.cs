using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5F;
    [SerializeField] float spawnRandomFactor = 0.2F;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2F;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Vector2> GetPathWaypoints()
    {
        List<Vector2> waypoints = new List<Vector2>();

        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child.position);
        }

        return waypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
