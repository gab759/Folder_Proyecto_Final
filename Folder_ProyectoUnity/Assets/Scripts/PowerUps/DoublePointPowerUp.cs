using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePointPowerUp : PowerUpBase
{
    public override void ActivatePowerUp(GameManager gameManager)
    {
        gameManager.ActivateDoublePoint(powerUpData.duration);
        base.Activate();
    }
}