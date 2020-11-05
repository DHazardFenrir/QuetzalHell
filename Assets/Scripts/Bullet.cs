using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null)
            {
                Debug.Log("Buuu");
                
                enemy.Damage(damage);
                Destroy(this.gameObject);
            }
           
        }

        if (other.CompareTag("Player"))
        {
            HealthPlayer player = other.GetComponent<HealthPlayer>();

            if(player != null)
            {
                player.Damage(damage);
                Destroy(this.gameObject);
            }
           
        }

        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void Init(int damage)
    {
        
        this.damage = damage;
       
       
    }
}
