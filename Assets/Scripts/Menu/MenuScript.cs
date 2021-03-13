using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);

    }
    public void Setting()
    {

    }
    public void Exit()
    {
        Application.Quit();
        
    }
}
