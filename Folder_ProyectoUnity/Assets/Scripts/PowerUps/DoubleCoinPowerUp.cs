using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinPowerUp : PowerUpBase
{
    public override string PowerUpTag => "DoubleCoin";

    public override void Activate()
    {
        base.Activate();
        Debug.LogError("Doble monedas activado");
    }
}