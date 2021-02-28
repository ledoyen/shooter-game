using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] public WaveConfig waveConfig;
    List<Vector2> waypoints;
    [SerializeField] float speed = 10F;

    int currentTargetIndex = 1;

    private Action onDestroyCallback;

    private void Start()
    {
        waypoints = waveConfig.GetPathWaypoints();
        transform.position = waypoints[0];
    }

    private void Update()
    {
        if (transform.position.Equals(waypoints[currentTargetIndex]))
        {
            currentTargetIndex++;
        }
        if (currentTargetIndex >= waypoints.Count)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex], Time.deltaTime * speed);
        }
    }

    private void OnDestroy()
    {
        onDestroyCallback();
    }

    public void SetOnDestroyCallback(Action onDestroyCallback)
    {
        this.onDestroyCallback = onDestroyCallback;
    }
}
