using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] bool was_started = false;
    private void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            if (was_started)
            {
                Upgrades.instance.bonus_hearts = 0;
                Upgrades.instance.dash_cdr = 1;
                Upgrades.instance.regen = 0;
                FortunePoints.instance.fortune_points = 0;
            }
            else was_started = true;

        }

    }


}
