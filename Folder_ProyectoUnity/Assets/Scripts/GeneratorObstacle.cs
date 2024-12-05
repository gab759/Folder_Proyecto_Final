using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    private float[] nextSpawnTimes;

    private void Start()
    {
        nextSpawnTimes = new float[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            nextSpawnTimes[i] = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void Update()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Time.time >= nextSpawnTimes[i])
            {
                SpawnObstacleAtPoint(i);
                nextSpawnTimes[i] = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
            }
        }
    }

    private void SpawnObstacleAtPoint(int spawnPointIndex)
    {
        GameObject selectedPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        Transform spawnPoint = spawnPoints[spawnPointIndex];
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}