using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private Stack<PowerUpBase> powerUpStack = new Stack<PowerUpBase>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            UsePowerUp();
        }
    }

    public void CollectPowerUp(PowerUpBase powerUp)
    {
        powerUpStack.Push(powerUp);
        Debug.Log("Power-Up recogido: " + powerUp.PowerUpTag);
    }

    public void UsePowerUp()
    {
        if (powerUpStack.count > 0)
        {
            PowerUpBase activePowerUp = powerUpStack.Pop();
            Debug.Log("Usando Power-Up: " + activePowerUp.PowerUpTag);
            activePowerUp.Activate();
        }
        else
        {
            Debug.Log("No hay más Power-Ups en la pila ");
        }
    }
}