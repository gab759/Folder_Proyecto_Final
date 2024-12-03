using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Atributos del Player: ")]
    //[SerializeField] private int playerLife;
    [SerializeField] private int playerCoins;
    [SerializeField] private Transform magnetPivot;
    public Transform MagnetPivot => magnetPivot;
    private Coroutine magnetCoroutine;
    public event Action<bool> OnMagnetActivate;
    public event Action<int> OnCoinUpdate;
    public event Action OnLose;
    public event Action<AudioClip> OnSFXPlay;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }
    private void Start()
    {
        playerCoins = 0;
    }
    public void GainCoin()
    {
        playerCoins++;

        OnCoinUpdate?.Invoke(playerCoins);
    }
    public void ActivateMagnet(float duration)
    {
        OnMagnetActivate?.Invoke(true);
        Debug.Log("Imán activado.");

        if (magnetCoroutine != null)
        {
            StopCoroutine(magnetCoroutine);
        }

        magnetCoroutine = StartCoroutine(DesactivateMagnet(duration));
    }
    public void TriggerLose()
    {
        OnLose?.Invoke();
        Debug.Log("Has perdido.");
    }
    public void PlaySFX(AudioClip clip)
    {
        OnSFXPlay?.Invoke(clip);
    }
    private IEnumerator DesactivateMagnet(float duration)
    {
        yield return new WaitForSeconds(duration);
        OnMagnetActivate?.Invoke(false);
        Debug.Log("Imán desactivado.");
    }
    /*public void ModifyLife(int modify)
    {
        playerLife = Math.Clamp(playerLife + modify, 0, 3);

        OnLifeUpdate?.Invoke(playerLife);

        ValidaeLife();
    } 
    private void ValidaeLife()
    {
        if (playerLife <= 0)
        {
            OnLose?.Invoke();
        }
    }*/
}
