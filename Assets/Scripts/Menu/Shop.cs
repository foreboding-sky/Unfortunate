using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop_menu;
    public Text text;


    public void Return()
    {
        SceneManager.LoadScene(0);       
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


}


