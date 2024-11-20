using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImanPowerUp : PowerUpBase
{
    public override string PowerUpTag => "Iman";

    public override void Activate()
    {
        base.Activate();
        Debug.LogError("Iman activado");
    }
}