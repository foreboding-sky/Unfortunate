using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    void SelectLevel(float angle)
    {
        switch(angle)
        {
            case var n when (n >= 0 && n < 45):
                SceneManager.LoadScene(1);
                break;
            case var n when (n >= 45 && n < 90):
                SceneManager.LoadScene(2);
                break;
            case var n when (n >= 90 && n < 135):
                SceneManager.LoadScene(3);
                break;
            case var n when (n >= 135  && n < 180):
                SceneManager.LoadScene(4);
                break;
            case var n when (n >= 180 && n < 225):
                SceneManager.LoadScene(5);
                break;
            case var n when (n >= 225 && n < 270):
                SceneManager.LoadScene(6);
                break;
            case var n when (n >= 270 && n < 315):
                SceneManager.LoadScene(7);
                break;
            case var n when (n >= 315 && n < 360):
                SceneManager.LoadScene(8);
                break;
        }
    }


}
