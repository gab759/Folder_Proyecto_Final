using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpController : MonoBehaviour
{
    private MyQueue<PowerUpBase> powerUpQueue = new MyQueue<PowerUpBase>();
    [SerializeField] private UiManager uiManager;
    public void PowerUpUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UsePowerUp();
        }
    }
    public void CollectPowerUp(PowerUpBase powerUp)
    {
        powerUpQueue.Enqueue(powerUp);
        //Debug.Log("Power-Up recogido: " + powerUp.PowerUpTag);

        uiManager.AddPowerUpToUI(powerUp.powerUpData.icon);
    }

    public void UsePowerUp()
    {
        if (!powerUpQueue.IsEmpty())
        {
            PowerUpBase activePowerUp = powerUpQueue.Dequeue();
            //Debug.Log("Usando Power-Up: " + activePowerUp.PowerUpTag);

            activePowerUp.ActivatePowerUp(GameManager.Instance);

            uiManager.RemovePowerUpFromUI(activePowerUp.powerUpData.icon);
        }
        else
        {
            Debug.LogWarning("No hay mas Power-Ups en la cola");
        }
    }
}