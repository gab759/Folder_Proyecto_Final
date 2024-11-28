using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinsText;
    public GameObject panelGameOver;
    private float score = 0;
    private float scoreIncreaseRate = 15f;

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
    private void OnCoinUpdate(int coins)
    {
        coinsText.text = coins.ToString();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Puntaje: " + Mathf.FloorToInt(score);
    }
}