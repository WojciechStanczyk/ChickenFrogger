
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;
    [SerializeField] public static float maxHealth = 3;
    public static float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar(maxHealth, currentHealth);
    }

    private void Update()
    {
        HealthUpdate();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void HealthUpdate()
    {
        UpdateHealthBar(maxHealth, currentHealth);
    }

}
