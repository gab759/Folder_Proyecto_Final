using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceSfx;

    private void OnEnable()
    {
        GameManager.Instance.OnSFXPlay += PlayCoin;
        GameManager.Instance.OnSFXPlay += PlayCollectPowerUp;
        GameManager.Instance.OnSFXPlay += PlayUsePowerUp;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnSFXPlay -= PlayCoin;
        GameManager.Instance.OnSFXPlay -= PlayCollectPowerUp;
        GameManager.Instance.OnSFXPlay -= PlayUsePowerUp;
    }
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnSFXPlay += PlayCoin;
            GameManager.Instance.OnSFXPlay += PlayCollectPowerUp;
            GameManager.Instance.OnSFXPlay += PlayUsePowerUp;
        }
        else
        {
            Debug.LogWarning("GameManager es null");
        }
    }
    private void PlayCoin(AudioClip clip)
    {

        audioSourceSfx.PlayOneShot(clip); 

    }
    private void PlayCollectPowerUp(AudioClip clip)
    {

        audioSourceSfx.PlayOneShot(clip);

    }
    private void PlayUsePowerUp(AudioClip clip)
    {

        audioSourceSfx.PlayOneShot(clip);

    }
}