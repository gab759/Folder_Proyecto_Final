using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinPowerUp : PowerUpBase
{
    //public override string PowerUpTag => "DoubleCoin";
    private void Start()
    {
        Vector3 adjustedPosition = transform.position;
        adjustedPosition.y -= 0.684f;
        transform.position = adjustedPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void Activate()
    {
        //base.Activate();
        //Debug.LogError("Doble monedas activado");
    }
}