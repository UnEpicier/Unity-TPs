using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    private float nextInterval = 1f; // Second(s)
    private float lastY = -3.33f;

    private void Start()
    {
        InvokeRepeating(nameof(spawnPlatform), 0, nextInterval);
    }

    private void spawnPlatform()
    {
        float startX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        float startY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 50f, 0)).y;
        float endY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height - 50f, 0)).y;

        int size = Random.Range(3, 7);

        if (size <= 3)
        {
            nextInterval = Random.Range(.7f, 2f);
        } else if (size > 3)
        {
            nextInterval = Random.Range(2f, 4f);
        }

        float y = Random.Range(startY, endY);

        while (y == lastY || y < lastY - 2f || y > lastY + 2f)
        {
            y = Random.Range(startY, endY);
        }

        Vector3 position = new Vector3(
            startX,
            y,
            0
        );

        lastY = y;

        GameObject spawned = Instantiate(platform, position, Quaternion.identity);

        spawned.GetComponentInChildren<Platform>().Size = size;
    }
}
