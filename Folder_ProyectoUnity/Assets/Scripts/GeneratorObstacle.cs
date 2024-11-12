using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab del obstáculo que se generará
    public Transform[] spawnPoints;    // Array de posiciones de spawn (Transform) donde se generarán los obstáculos
    public float spawnInterval = 2f;   // Intervalo de tiempo entre cada aparición de obstáculos

    private float lastSpawnZ;          // Posición Z donde se generó el último obstáculo

    private void Start()
    {

        lastSpawnZ = spawnPoints[0].position.z;
        SpawnObstacle(); // Genera el primer obstáculo
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval); // Inicia la generación continua
    }

    private void SpawnObstacle()
    {
        // Selecciona una posición aleatoria del arreglo de spawnPoints
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Crea el obstáculo en la posición seleccionada
        Vector3 spawnPosition = new Vector3(selectedSpawnPoint.position.x, selectedSpawnPoint.position.y, lastSpawnZ + spawnInterval);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Actualiza la posición Z para el próximo obstáculo
        lastSpawnZ = spawnPosition.z;
    }
}