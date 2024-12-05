using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImanPowerUp : PowerUpBase
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 40, 110);
    }
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