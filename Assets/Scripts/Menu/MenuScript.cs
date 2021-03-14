using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void Settings()
    {
        settingsPanel.SetActive(true);

    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
        
    }
}
