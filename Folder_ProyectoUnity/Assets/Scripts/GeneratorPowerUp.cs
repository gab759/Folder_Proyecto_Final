using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPowerUp : MonoBehaviour
{
    public GameObject[] powerUpsPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 10f;

    private float lastSpawnZ;

    private void Start()
    {
        lastSpawnZ = spawnPoints[0].position.z;
        SpawnPowerUp();
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        GameObject selectedPrefab = powerUpsPrefabs[Random.Range(0, powerUpsPrefabs.Length)];
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Vector3 spawnPosition = new Vector3(selectedSpawnPoint.position.x, selectedSpawnPoint.position.y, lastSpawnZ);

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}