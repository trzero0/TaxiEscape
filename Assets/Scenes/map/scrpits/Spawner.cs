using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cube;
    public float minDistanceBetweenCubes = 1.0f; // Minimum distance between cubes

    private float spawnRate = 2.0f; // Initial spawn rate (2 objects per second)
    private float nextSpawnTime = 0.0f;
    private float nextSpawnRateChangeTime = 2.0f; // Time interval to change spawn rate

    void Start()
    {
        nextSpawnTime = Time.time + 1.0f / spawnRate; // Initial spawn time
        nextSpawnRateChangeTime = Time.time + nextSpawnRateChangeTime; // Initial rate change time
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (CanSpawnCube())
            {
                Spawn();
                nextSpawnTime += 1.0f / spawnRate; // Calculate the next spawn time
            }
        }

        if (Time.time >= nextSpawnRateChangeTime)
        {
            spawnRate *= 1.1f; // Double the spawn rate
            nextSpawnRateChangeTime += 10; // Set the next rate change time
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(Random.Range(-20, 20)), 52, 0.1f);

        // Check for collisions before spawning
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, minDistanceBetweenCubes);

        if (colliders.Length == 0)
        {
            Instantiate(cube, spawnPosition, Quaternion.Euler(90, -180, 0));
        }
    }

    bool CanSpawnCube()
    {
        // Check if the area around the spawn point is clear
        Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(Random.Range(-20, 20)), 52, 0.6f);
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, minDistanceBetweenCubes);

        return colliders.Length == 0;
    }
}
