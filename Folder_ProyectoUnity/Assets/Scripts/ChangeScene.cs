using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject panelSettings;
    public GameObject panelShop;

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void ActivatePanel()
    {
        panelSettings.SetActive(true);
    }
    public void DeactivatePanel()
    {
        panelSettings.SetActive(false);
        Time.timeScale = 1;
    }
    public void ActivatePanelShop()
    {
        panelShop.SetActive(true);
    }
    public void DesactivatePanelShop()
    {
        panelShop.SetActive(false);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        panelSettings.SetActive(true);
        Time.timeScale = 0;
    }
}
