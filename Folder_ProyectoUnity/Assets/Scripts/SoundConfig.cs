using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeConfig", menuName = "ScriptableObjects/VolumeConfig", order = 1)]
public class SoundConfig : ScriptableObject
{
    public float volume = 1.0f;
}