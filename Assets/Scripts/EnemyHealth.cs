using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Min(1)]
    public int maxHealth = 100;

    public int currentHealth = 0;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        Debug.Log(gameObject.name + "Health:" + currentHealth + "/" + maxHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + "died");
        Destroy(gameObject);
    }
}