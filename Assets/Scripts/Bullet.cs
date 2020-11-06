using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public enum Type { red, blue, yellow}
public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] BulletType type = default;
    // Start is called before the first frame update

    public BulletType Type { get { return type; } }
    

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
