using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour, IDamageable
{
    [SerializeField] int healthPoints;
    [SerializeField] Image healthBar;

    public event Action<int> onDamageTaken;
    private int currentHP;

    void Start()
    {
        currentHP = healthPoints;
        onDamageTaken?.Invoke(currentHP);
        healthBar.fillAmount = healthPoints;
    }

    public void Damage(int amount)
    {
        healthPoints -= amount;
        onDamageTaken?.Invoke(currentHP);

        healthBar.fillAmount = (currentHP / healthPoints);

        if (healthPoints <= 0)
        {
            currentHP = 0;
            Destroy(this.gameObject);
            GameManager.Instance.ShowGameOver();
        }
        onDamageTaken?.Invoke(currentHP);
    }    
}
