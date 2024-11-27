using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject panel;
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
        panel.SetActive(true);
    }
    public void DeactivatePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
