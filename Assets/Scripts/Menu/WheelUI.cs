using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelUI : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(9);
    }
    public void Shop()
    {
        SceneManager.LoadScene(10);
    }

}
