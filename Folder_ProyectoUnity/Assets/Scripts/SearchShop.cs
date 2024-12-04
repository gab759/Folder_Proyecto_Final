using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SearchShop : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_InputField searchField;
    [SerializeField] private Image resultImage;
    [SerializeField] private TextMeshProUGUI resultText;
    private string key;
    [Header("PowerUp Data")]
    [SerializeField] private PowerUpData[] powerUpData;

    private TablaHash<PowerUpData> powerUpTable;

    private void Awake()
    {
        powerUpTable = new TablaHash<PowerUpData>();
        powerUpTable.InitializeAlphabet();

        for (int i = 0; i < powerUpData.Length; i++)
        {
            key = powerUpData[i].name.ToLower();
            powerUpTable.Add(key, powerUpData[i]);
        }

        ClearResults();
    }

    public void SearchPowerUp()
    {
        string searchKey = searchField.text.ToLower();
        PowerUpData foundPowerUp = powerUpTable.Search(searchKey);

        if (foundPowerUp != null)
        {
            resultImage.sprite = foundPowerUp.icon;
            resultImage.gameObject.SetActive(true);
            resultText.text = foundPowerUp.powerUpName;
        }
        else
        {
            ClearResults();
        }
    }

    private void ClearResults()
    {
        resultImage.sprite = null;
        resultImage.gameObject.SetActive(false);
        resultText.text = "";
    }
}