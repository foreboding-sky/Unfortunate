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
    private void Start()
    {
        if (maxHealth > hearts.Length)
            maxHealth = hearts.Length;
        if (health > maxHealth)
            health = maxHealth;
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
    public void Death()
    {
        if (health <= 0)
        {
            //SceneManager.LoadScene(0);
            Debug.Log("ded");
            health = maxHealth;
        }
    }
}
