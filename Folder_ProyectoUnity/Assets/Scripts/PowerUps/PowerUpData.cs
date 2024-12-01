using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp", menuName = "PowerUp/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    public string powerUpName;
    public Sprite icon;
    public float duration;
}