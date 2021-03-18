﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static Upgrades instance = null;
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
    public int bonus_hearts = 0;
    public float dash_cdr = 1;
    public int regen = 0;

    public string BuyHearts(int points)
    {
        if(bonus_hearts >=2)
        {
            return "You cannot buy more hearts";
        }
        else
        {
            if (FortunePoints.instance.CanBuy(points))
            {
                bonus_hearts += 1;
                return "You bought one more heart!";
            }
            else return "You dont have enough points!";
        }
    }

    public string BuyDash(int points)
    {
        if (dash_cdr <= 0.5f)
        {
            return "You cannot reduce dash cooldown more!";
        }
        else
        {
            if (FortunePoints.instance.CanBuy(points))
            {
                dash_cdr -= 0.25f;
                return "You reduced dash cooldown!";
            }
            else return "You dont have enough points!";
        }
    }
    public string BuyRegen(int points)
    {
        if (regen >= 2)
        {
            return "You cannot increase your regen!";
        }
        else
        {
            if (FortunePoints.instance.CanBuy(points))
            {
                regen += 1;
                return "You increased your regen";
            }
            else return "You dont have enough points!";
        }
    }

}
