using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeConfig", menuName = "ScriptableObjects/VolumeConfig", order = 1)]
public class VolumeConfig : ScriptableObject
{
    [Range(0f, 3f)]
    public float volume = 1.5f;
}