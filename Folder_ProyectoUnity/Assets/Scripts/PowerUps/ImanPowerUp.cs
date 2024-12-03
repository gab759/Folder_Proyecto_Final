using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImanPowerUp : PowerUpBase
{
    public override void ActivatePowerUp(GameManager gameManager)
    {
        gameManager.ActivateMagnet(powerUpData.duration);
        base.Activate();
    }
    public override void Activate()
    {
        base.Activate();
    }

}