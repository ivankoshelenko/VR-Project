using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;

    void Update()
    {
        
    }

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
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
    }
}
