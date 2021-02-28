using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed = 10F;

    int currentTargetIndex = 1;

    private void Start()
    {
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        if (transform.position.Equals(waypoints[currentTargetIndex].position))
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
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * speed);
        }
    }
}
