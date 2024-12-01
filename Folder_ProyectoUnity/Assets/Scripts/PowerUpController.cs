using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private MyQueue<PowerUpBase> powerUpQueue = new MyQueue<PowerUpBase>();
    [SerializeField] private UiManager uiManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            UsePowerUp();
        }
    }

    public void CollectPowerUp(PowerUpBase powerUp)
    {
        powerUpQueue.Enqueue(powerUp);
        Debug.Log("Power-Up recogido: " + powerUp.PowerUpTag);

        uiManager.AddPowerUpToUI(powerUp.powerUpData.icon);
    }

    public void UsePowerUp()
    {
        if (!powerUpQueue.IsEmpty())
        {
            PowerUpBase activePowerUp = powerUpQueue.Dequeue();
            Debug.Log("Usando Power-Up: " + activePowerUp.PowerUpTag);

            activePowerUp.Activate();

            uiManager.RemovePowerUpFromUI(activePowerUp.powerUpData.icon);
        }
        else
        {
            Debug.LogWarning("No hay mas Power-Ups en la cola");
        }
    }
}