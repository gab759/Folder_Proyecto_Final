using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Vector3 adjustedPosition = transform.position;
        adjustedPosition.y -= 0.684f;
        transform.position = adjustedPosition;

        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}