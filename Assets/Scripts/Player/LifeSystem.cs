using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite activeHeart;
    [SerializeField] private Sprite disabledHeart;
    [SerializeField] private int regen; 
    private void Start()
    {
        maxHealth = PlayerStats.instance.max_hearts + Upgrades.instance.bonus_hearts;
        health = PlayerStats.instance.curr_hearts;
        regen = Upgrades.instance.regen;
        Heal(regen);
        if (maxHealth > hearts.Length)
            maxHealth = hearts.Length;
        if (health > maxHealth)
            health = maxHealth;
    }

    private void OnDestroy()
    {
        PlayerStats.instance.curr_hearts = health;
    }
    void Update()
    {
        SpriteDisplay();
        LifesDisplay();
    }
    void SpriteDisplay()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = activeHeart;
                continue;
            }
            hearts[i].sprite = disabledHeart;
        }
    }
    void LifesDisplay()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
                continue;
            }
            hearts[i].enabled = false;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Death();
        }
    }
    public void Heal(int healing)
    {
        health += healing;
        if (health > maxHealth)
            health = maxHealth;
    }
    public void Death()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            PauseMenu.instance.DEATH.SetActive(true);
            health = maxHealth;
        }
    }
}
