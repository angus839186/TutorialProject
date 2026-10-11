using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [Min(1)]
    public int maxHealth = 100;

    public int currentHealth = 0;

    public event Action OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;
        if (damage <= 0) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        OnHealthChanged?.Invoke();

        Debug.Log("Player Health:" + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
    }
}