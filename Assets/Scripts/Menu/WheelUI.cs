using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WheelUI : MonoBehaviour
{
    public Text levels_completed;
    public void MainMenu()
    {
        SaveSystem.instance.Save();
        SceneManager.LoadScene(0);
        
    }
    public void Shop()
    {
        SceneManager.LoadScene(10);
    }


    private void Update()
    {
        levels_completed.text = $"Levels completed: { CompletedLevels.instance.CheckCompleted()}";
    }

}
