using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IDamageable
{
    [SerializeField] int healthPoints;
    public event Action<int> onDamageTaken;
    private int currentHP;



    public void Damage(int amount)
    {
        healthPoints -= amount;
        onDamageTaken?.Invoke(currentHP);

        if(healthPoints <= 0)
        {
            currentHP = 0;
            Destroy(this.gameObject);
            GameManager.Instance.ShowGameOver();
        }
        onDamageTaken?.Invoke(currentHP);
    }

    void Start()
    {
        currentHP = healthPoints;
        onDamageTaken?.Invoke(currentHP);
    }

  
}
