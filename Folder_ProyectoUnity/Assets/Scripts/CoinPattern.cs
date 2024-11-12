using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCoinPattern", menuName = "Coin Pattern")]
public class CoinPattern : ScriptableObject
{
    public GameObject coinPrefab;
    public Vector3[] positions;
}