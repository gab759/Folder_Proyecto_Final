using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
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
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Vector3 spawnPosition = new Vector3(selectedSpawnPoint.position.x, selectedSpawnPoint.position.y, lastSpawnZ + spawnInterval);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        lastSpawnZ = spawnPosition.z;
    }
}