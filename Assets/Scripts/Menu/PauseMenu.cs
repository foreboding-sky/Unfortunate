using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settings;
    public GameObject pause_menu;
    bool paused = false;

    public void Save()
    {
        SaveSystem.instance.Save();
    }
    public void Load()
    {
        SaveSystem.instance.Load();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pause_menu.SetActive(false);
        paused = false;
    }
    public void Settings()
    {
        settings.SetActive(true);
    }

    public void ToMainMenu()
    {
        pause_menu.SetActive(false);
        paused = false;
        SaveSystem.instance.Save();
        SceneManager.LoadScene(0);
    }
    public void QuitToDesktop()
    {
        Application.Quit();
    }

    // Update is called once per frame

    private void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused == true)
                {
                    Time.timeScale = 1;
                    pause_menu.SetActive(false);
                    paused = false;
                }
                else
                {
                    Time.timeScale = 0;
                    pause_menu.SetActive(true);
                    paused = true;
                }

            }
        }

    }
}
