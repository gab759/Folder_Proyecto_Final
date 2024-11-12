using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab del obst�culo que se generar�
    public Transform[] spawnPoints;    // Array de posiciones de spawn (Transform) donde se generar�n los obst�culos
    public float spawnInterval = 2f;   // Intervalo de tiempo entre cada aparici�n de obst�culos

    private float lastSpawnZ;          // Posici�n Z donde se gener� el �ltimo obst�culo

    private void Start()
    {

        lastSpawnZ = spawnPoints[0].position.z;
        SpawnObstacle(); // Genera el primer obst�culo
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval); // Inicia la generaci�n continua
    }

    private void SpawnObstacle()
    {
        // Selecciona una posici�n aleatoria del arreglo de spawnPoints
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Crea el obst�culo en la posici�n seleccionada
        Vector3 spawnPosition = new Vector3(selectedSpawnPoint.position.x, selectedSpawnPoint.position.y, lastSpawnZ + spawnInterval);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Actualiza la posici�n Z para el pr�ximo obst�culo
        lastSpawnZ = spawnPosition.z;
    }
}