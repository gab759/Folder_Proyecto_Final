using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;

    private float lastSpawnZ;

    private void Start()
    {
        lastSpawnZ = spawnPoints[0].position.z;
        SpawnObstacle();
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }

    private void SpawnObstacle()
    {
        GameObject selectedPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Vector3 spawnPosition = new Vector3(selectedSpawnPoint.position.x, selectedSpawnPoint.position.y, lastSpawnZ);

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}