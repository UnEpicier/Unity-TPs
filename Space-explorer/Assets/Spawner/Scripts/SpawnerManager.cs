using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    /** --- SPAWNER POINTS ---------------------- */
    public GameObject startLine;
    public GameObject endline;

    private readonly int maxSpawn = 30;

    public GameObject asteroid;

    private static List<GameObject> entities = new();

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEntity), 0, Random.Range(0.1f, 0.5f));
    }

    private void Update()
    {
        // Destroy outter screen's asteroids
        List<GameObject> remainingEntities = new List<GameObject>();
        for (int i = 0; i < entities.Count; i++)
        {
            float y = entities[i].transform.position.y;
            
            if (y <= endline.transform.position.y)
            {
                Destroy(entities[i]);
            } else
            {
                remainingEntities.Add(entities[i]);
            }
        }
        entities = remainingEntities;
    }

    private void SpawnEntity()
    {
        if (entities.Count < maxSpawn)
        {
            float scaleX = startLine.transform.localScale.x / 2;
            float spawnX = Random.Range(startLine.transform.position.x - scaleX, startLine.transform.position.x + scaleX);

            // SPAWN ASTEROID
            GameObject spawned = Instantiate(asteroid, new Vector3(spawnX, startLine.transform.position.y, startLine.transform.position.z), Quaternion.identity);

            entities.Add(spawned);
        }
    }

    public static void AddAsteroid(GameObject asteroid)
    {
        entities.Add(asteroid);
    }

    public static void RemoveAsteroid(GameObject asteroid)
    {
        entities.Remove(asteroid);
    }
}
