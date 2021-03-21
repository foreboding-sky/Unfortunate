using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpgradesUI : MonoBehaviour
{

    public Text bonus_hearts;
    public Text dash_cdr;
    public Text regen;
    private void Awake()
    {
        bonus_hearts.text = $"Bonus Hearts: {Upgrades.instance.bonus_hearts}/2";
        dash_cdr.text = $"Dash cooldown: {Upgrades.instance.dash_cdr * 100}%/50%";
        regen.text = $"Regen: {Upgrades.instance.regen}/2";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bonus_hearts.text = $"Bonus Hearts: {Upgrades.instance.bonus_hearts}/2";
            dash_cdr.text = $"Dash cooldown: {Upgrades.instance.dash_cdr*100}%/50%";
            regen.text = $"Regen: {Upgrades.instance.regen}/2";
        }
        
    }
}
