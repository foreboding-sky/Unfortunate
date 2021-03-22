using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance = null;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    public GameObject settings;
    public GameObject pause_menu;
    public GameObject DEATH;
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


    public void TRYAGAIN()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(9);
        DEATH.SetActive(false);
        PlayerStats.instance.curr_hearts = 5;
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
