using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public Slider healthBar;

    void Start()
    {
        healthBar.value = currentHealth;
    }
    void Update()
    {
       //healthBar.value = currentHealth;
    }

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        Debug.Log("Player hit!" +  currentHealth);
        if (currentHealth < 0)
            Death();
    }
    public void Death() 
    {
        Debug.Log("Death");
    }
    public void Heal(float health)
    {
        currentHealth += health;
        healthBar.value = currentHealth;
    }
}
