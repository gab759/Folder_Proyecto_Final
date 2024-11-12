using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0;
    private float scoreIncreaseRate = 15f;

    private void Update()
    {
        score += scoreIncreaseRate * Time.deltaTime;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Puntaje: " + Mathf.FloorToInt(score);
    }
}