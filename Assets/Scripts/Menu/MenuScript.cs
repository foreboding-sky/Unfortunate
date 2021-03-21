using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{
    public GameObject settingsPanel;

    public void NewGame()
    {

        Time.timeScale = 1;
        SaveSystem.instance.NewGame();
        SceneManager.LoadScene(9);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        SaveSystem.instance.Load();
        SceneManager.LoadScene(9);
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);

    }
    public void Exit()
    {
        Application.Quit();
        
    }
}
