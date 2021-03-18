using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop_menu;
    //public GameObject text;
    public Text text;
    bool paused = false;
    public void Resume()
    {
        Time.timeScale = 1;
        shop_menu.SetActive(false);
        paused = false;
    }
    public void BuyHearts()
    {
        text.text = Upgrades.instance.BuyHearts(5);
    }
    public void BuyDash()
    {
        text.text = Upgrades.instance.BuyDash(5);
    }
    public void BuyRegen()
    {
        text.text = Upgrades.instance.BuyRegen(5);
    }



    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused == true)
            {
                Time.timeScale = 1;
                shop_menu.SetActive(false);
                paused = false;
            }
            else
            {
                Time.timeScale = 0;
                shop_menu.SetActive(true);
                paused = true;
            }

        }

    }
}


