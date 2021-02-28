using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10F;
    [SerializeField] float shipWingWidth = 0.2F;
    [SerializeField] float topInaccesibleScreenPortion = 0.33F; // 33 %
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float timeBetweenFires = 0.2F; // -> 5 times per second
    [SerializeField] float laserSpeed = 10F;

    float minY;
    float maxY;
    float minX;
    float maxX;

    float lastTimeShootingOccured = 0F;

    void Start()
    {
        Camera camera = Camera.main;

        Vector3 min = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = camera.ViewportToWorldPoint(new Vector3(1, 1 - topInaccesibleScreenPortion, 0));

        minX = min.x + shipWingWidth;
        minY = min.y + shipWingWidth;

        maxX = max.x - shipWingWidth;
        maxY = max.y;
    }

    void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1") && lastTimeShootingOccured < Time.time - timeBetweenFires)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            lastTimeShootingOccured = Time.time;
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newX = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newY = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newX, newY);
    }
}
