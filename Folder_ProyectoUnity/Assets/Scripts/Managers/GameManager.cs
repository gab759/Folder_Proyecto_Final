using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Atributos del Player: ")]
    [SerializeField] private int playerCoins;
    [SerializeField] private Transform magnetPivot;
    private bool isDoubleCoinActive = false;
    public Transform MagnetPivot => magnetPivot;
    private Coroutine magnetCoroutine;
    private Coroutine doubleCoinCoroutine;
    private Coroutine doublePointCoroutine;
    public event Action<bool> OnMagnetActivate;
    public event Action<bool> OnDoubleCoinActive;
    public event Action<bool> OnDoublePointActive;
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
        int coinsToAdd = 1;
        if (isDoubleCoinActive)
        {
            coinsToAdd = 2;
        }

        playerCoins += coinsToAdd;
        OnCoinUpdate?.Invoke(playerCoins);
    }
    public void ActivateMagnet(float duration)
    {
        OnMagnetActivate?.Invoke(true);
        Debug.Log("Iman activado");

        if (magnetCoroutine != null)
        {
            StopCoroutine(magnetCoroutine);
        }

        magnetCoroutine = StartCoroutine(DesactivateMagnet(duration));
    }
    public void ActivateDoubleCoin(float duration)
    {
        isDoubleCoinActive = true;
        OnDoubleCoinActive?.Invoke(true);

        if (doubleCoinCoroutine != null)
        {
            StopCoroutine(doubleCoinCoroutine);
        }

        doubleCoinCoroutine = StartCoroutine(DeactivateDoubleCoin(duration));
    }

    public void ActivateDoublePoint(float duration)
    {
        OnDoublePointActive?.Invoke(true);

        if (doublePointCoroutine != null)
        {
            StopCoroutine(doublePointCoroutine);
        }

        doublePointCoroutine = StartCoroutine(DeactivateDoublePoint(duration));
    }
    public void TriggerLose()
    {
        OnLose?.Invoke();
        Debug.Log("Has perdido");
    }
    public void PlaySFX(AudioClip clip)
    {
        OnSFXPlay?.Invoke(clip);
    }
    private IEnumerator DesactivateMagnet(float duration)
    {
        yield return new WaitForSeconds(duration);
        OnMagnetActivate?.Invoke(false);
    }

    private IEnumerator DeactivateDoubleCoin(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDoubleCoinActive = false;
        OnDoubleCoinActive?.Invoke(false);
        Debug.Log("Doble monedas desactivado");
    }

    private IEnumerator DeactivateDoublePoint(float duration)
    {
        yield return new WaitForSeconds(duration);
        OnDoublePointActive?.Invoke(false);
    }
}
