using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IDamageable
{
    [SerializeField] int healthPoints;

    public void Damage(int amount)
    {
        healthPoints -= amount;

        if(healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
