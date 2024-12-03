using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer _compAudioMixer;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSfx;

    [SerializeField] private SoundConfig masterVolumeConfig;
    [SerializeField] private SoundConfig musicVolumeConfig;
    [SerializeField] private SoundConfig sfxVolumeConfig;
    void Start()
    {
        sliderMaster.value = masterVolumeConfig.volume;
        sliderMusic.value = musicVolumeConfig.volume;
        sliderSfx.value = sfxVolumeConfig.volume;

        //sliderMaster.onValueChanged.AddListener(SetMasterVolume);
        //sliderMusic.onValueChanged.AddListener(SetMusicVolume);
        //sliderSfx.onValueChanged.AddListener(SetSFXVolume);
    }
    public void SetMasterVolume()
    {
        masterVolumeConfig.volume = sliderMaster.value;
        _compAudioMixer.SetFloat("Master", Mathf.Log10(masterVolumeConfig.volume) * 20);
    }

    public void SetMusicVolume()
    {
        musicVolumeConfig.volume = sliderMusic.value;
        _compAudioMixer.SetFloat("Music", Mathf.Log10(musicVolumeConfig.volume) * 20);
    }

    public void SetSFXVolume()
    {
        sfxVolumeConfig.volume = sliderSfx.value;
        _compAudioMixer.SetFloat("SFX", Mathf.Log10(sfxVolumeConfig.volume) * 20);
    }
}