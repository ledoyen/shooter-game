using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10F;
    [SerializeField] float shipWingWidth = 0.2F;
    [SerializeField] float topInaccesibleScreenPortion = 0.33F; // 33 %

    float minY;
    float maxY;
    float minX;
    float maxX;

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
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newX = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newY = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newX, newY);
        Debug.Log(transform.position);
    }
}
