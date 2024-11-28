using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public abstract string PowerUpTag { get; }
    public float speed = 5f;

    public virtual void Activate()
    {
        Debug.Log("Activando" + PowerUpTag);
    }
    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpController controller = other.GetComponent <PowerUpController>();
            if (controller != null)
            {
                controller.CollectPowerUp(this);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}