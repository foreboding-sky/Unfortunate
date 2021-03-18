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

    public void Resume()
    {
        Time.timeScale = 1;
        pause_menu.SetActive(false);
        paused = false;
    }
    public void Settings()
    {
        settings.SetActive(true);
        pause_menu.SetActive(false);
    }
    public void ExitSettings()
    {
        settings.SetActive(false);
        pause_menu.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(9);
    }
    public void QuitToDesktop()
    {
        Application.Quit();
    }

    // Update is called once per frame

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
