using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinPowerUp : PowerUpBase
{
    private void Start()
    {
        Vector3 adjustedPosition = transform.position;
        adjustedPosition.y -= 0.684f;
        transform.position = adjustedPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void ActivatePowerUp(GameManager gameManager)
    {
        gameManager.ActivateDoubleCoin(powerUpData.duration);
        base.Activate();
    }
}