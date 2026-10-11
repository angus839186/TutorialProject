using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text healthText;

    void OnEnable()
    {
        playerHealth.OnHealthChanged += RefreshHealth;
    }

    void Start()
    {
        RefreshHealth();
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= RefreshHealth;
    }

    void RefreshHealth()
    {
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.currentHealth;

        healthText.text =
            playerHealth.currentHealth +
            " / " +
            playerHealth.maxHealth;
    }
}