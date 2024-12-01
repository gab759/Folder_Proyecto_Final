using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private Image[] powerUpSlots;
    [SerializeField] private Sprite emptySlotSprite;
    public GameObject panelGameOver;

    private MyQueue<Sprite> overflowQueue = new MyQueue<Sprite>();
    private float score = 0;
    private float scoreIncreaseRate = 15f;

    private void Start()
    {
        InitializePowerUpSlots();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnCoinUpdate += OnCoinUpdate;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinUpdate -= OnCoinUpdate;
    }

    private void Update()
    {
        score += scoreIncreaseRate * Time.deltaTime;
        UpdateScoreText();
    }

    private void InitializePowerUpSlots()
    {
        for (int i = 0; i < powerUpSlots.Length; i++)
        {
            powerUpSlots[i].sprite = emptySlotSprite;
        }
    }

    public void AddPowerUpToUI(Sprite powerUpIcon)
    {
        for (int i = 0; i < powerUpSlots.Length; i++)
        {
            if (powerUpSlots[i].sprite == emptySlotSprite)
            {
                powerUpSlots[i].sprite = powerUpIcon;
                return;
            }
        }

        overflowQueue.Enqueue(powerUpIcon);
        Debug.Log("Power-Up agregado a la cola provicional");
    }

    public void RemovePowerUpFromUI(Sprite powerUpIcon)
    {
        for (int i = 0; i < powerUpSlots.Length; i++)
        {
            if (powerUpSlots[i].sprite == powerUpIcon)
            {
                powerUpSlots[i].sprite = emptySlotSprite;

                for (int j = i; j < powerUpSlots.Length - 1; j++)
                {
                    powerUpSlots[j].sprite = powerUpSlots[j + 1].sprite;
                }

                if (!overflowQueue.IsEmpty())
                {
                    powerUpSlots[powerUpSlots.Length - 1].sprite = overflowQueue.Dequeue();
                    Debug.Log("Power-Up movido a la cola provisional");
                }
                else
                {
                    powerUpSlots[powerUpSlots.Length - 1].sprite = emptySlotSprite;
                }

                return;
            }
        }

        Debug.LogWarning("El power-up no se encontro en los slots :c ");
    }

    private void OnCoinUpdate(int coins)
    {
        coinsText.text = coins.ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Puntaje: " + Mathf.FloorToInt(score);
    }
}