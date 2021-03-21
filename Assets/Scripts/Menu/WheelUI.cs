using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelUI : MonoBehaviour
{
    public void MainMenu()
    {
        SaveSystem.instance.Save();
        SceneManager.LoadScene(0);
        
    }
    public void Shop()
    {
        SceneManager.LoadScene(10);
    }

}
