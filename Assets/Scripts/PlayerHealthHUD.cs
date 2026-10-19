using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] TMP_Text healthText;

    void OnEnable()
    {
        playerHealth.OnHealthChanged += RefreshHealth;
    }
    void OnDisable()
    {
        playerHealth.OnHealthChanged -= RefreshHealth;
    }
    void Start()
    {
        RefreshHealth();
    }


    void RefreshHealth()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;
        healthText.text = playerHealth.currentHealth + "/" + playerHealth.maxHealth;
    }
}