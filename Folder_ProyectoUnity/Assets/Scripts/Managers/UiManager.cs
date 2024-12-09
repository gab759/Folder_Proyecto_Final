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
    [SerializeField] private Image doubleCoinIndicator;
    [SerializeField] private Image doublePointIndicator;
    public GameObject panelGameOver;

    private MyQueue<Sprite> overflowQueue = new MyQueue<Sprite>();
    private float score = 0;
    private float scoreIncreaseRate = 20f;
    private bool isDoublePointActive = false;
    [SerializeField] private TMP_Text[] scoreTexts;
    private SimplyLinkList<float> scoreList = new SimplyLinkList<float>();
    private void Start()
    {
        InitializePowerUpSlots();
        SetIndicatorState(doubleCoinIndicator, false);
        SetIndicatorState(doublePointIndicator, false);
        InitializeScoreTexts();
        UpdateScoreBoardUI();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnCoinUpdate += OnCoinUpdate;
        GameManager.Instance.OnLose += HandleLose;
        GameManager.Instance.OnDoubleCoinActive += UpdateDoubleCoinIndicator;
        GameManager.Instance.OnDoublePointActive += UpdateDoublePointIndicator;

    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinUpdate -= OnCoinUpdate;
        GameManager.Instance.OnLose -= HandleLose;
        GameManager.Instance.OnDoubleCoinActive -= UpdateDoubleCoinIndicator;
        GameManager.Instance.OnDoublePointActive -= UpdateDoublePointIndicator;

    }
    private void Update()
    {
        float pointsToAdd = scoreIncreaseRate * Time.deltaTime;
        if (isDoublePointActive)
        {
            pointsToAdd *= 2;
        }

        score += pointsToAdd;
        UpdateScoreText();
    }
    public void AddScore(float newScore)
    {
        scoreList.AddNodeAtEnd(newScore);
        SortScores();
        UpdateScoreBoardUI();
    }
    private void SortScores()
    {
        for (int i = 0; i < scoreList.Count - 1; i++)
        {
            int maxIndex = i;

            for (int j = i + 1; j < scoreList.Count; j++)
            {
                if (scoreList.GetNodeAtPosition(j) > scoreList.GetNodeAtPosition(maxIndex))
                {
                    maxIndex = j;
                }
            }

            // Intercambia valores
            if (maxIndex != i)
            {
                float temp = scoreList.GetNodeAtPosition(i);
                scoreList.ModifyAtPosition(scoreList.GetNodeAtPosition(maxIndex), i);
                scoreList.ModifyAtPosition(temp, maxIndex);
            }
        }
    }
    public void UpdateScoreBoardUI()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scoreList.Count)
            {
                float score = scoreList.GetNodeAtPosition(i);
                scoreTexts[i].text = (i + 1) + ". " + score.ToString();
            }
            else
            {
                scoreTexts[i].text = "---";
            }
        }
    }
    private void InitializeScoreTexts()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = "---";
        }
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
    private void HandleLose()
    {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
        UpdateScoreBoardUI();
        Debug.Log("LOSS");
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
        scoreText.text = "" + Mathf.FloorToInt(score);
    }
    private void UpdateDoubleCoinIndicator(bool isActive)
    {
        SetIndicatorState(doubleCoinIndicator, isActive);
    }

    private void UpdateDoublePointIndicator(bool isActive)
    {
        isDoublePointActive = isActive;
        SetIndicatorState(doublePointIndicator, isActive);
    }
    private void SetIndicatorState(Image indicator, bool isActive)
    {
        if (indicator != null)
        {
            indicator.gameObject.SetActive(isActive);

            if (isActive)
            {
                indicator.color = Color.white;
            }
            else
            {
                indicator.color = new Color(1, 1, 1, 0);
            }
        }
    }
}