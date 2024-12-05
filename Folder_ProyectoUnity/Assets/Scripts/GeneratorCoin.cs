using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCoin : MonoBehaviour
{
    public CoinPattern[] coinPattern;
    public Transform[] spawnPoints;
    public float spawnInterval = 7f;

    private float lastSpawnZ;

    private void Start()
    {
        lastSpawnZ = spawnPoints[0].position.z;
        SpawnCoins();
        InvokeRepeating("SpawnCoins", spawnInterval, spawnInterval);
    }

    private void SpawnCoins()
    {
        CoinPattern selectedPattern = coinPattern[Random.Range(0, coinPattern.Length)];

        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        for (int i = 0; i < selectedPattern.positions.Length; i++)
        {
            Vector3 spawnPosition = new Vector3(
                selectedSpawnPoint.position.x + selectedPattern.positions[i].x,
                selectedSpawnPoint.position.y + selectedPattern.positions[i].y,
                lastSpawnZ + selectedPattern.positions[i].z
            );

            Instantiate(selectedPattern.coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}