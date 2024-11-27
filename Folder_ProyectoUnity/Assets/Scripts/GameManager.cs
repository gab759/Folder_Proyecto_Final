using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Atributos del Player: ")]
    [SerializeField] private int playerLife;
    [SerializeField] private int playerCoins;
    public event Action<int> OnLifeUpdate;
    public event Action<int> OnCoinUpdate;
    public event Action OnLose;

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
    public void ModifyLife(int modify)
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
    }
}
