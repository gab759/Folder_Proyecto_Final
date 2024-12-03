using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public float speed = 5f;
    public PowerUpData powerUpData;
    public virtual void ActivatePowerUp(GameManager gameManager)
    {
        Activate();
    }
    public virtual void Activate()
    {
        Debug.Log("Activando" + powerUpData);
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