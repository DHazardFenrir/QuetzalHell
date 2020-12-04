using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;

public enum Type { red, blue, yellow}
public class Bullet : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] BulletType type = default;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    Rigidbody rb;

    // Start is called before the first frame update

    public BulletType Type { get { return type; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo");

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
        else
        {
            Destroy(this.gameObject, 1f);
        }
    }

    public void Init(int damage)
    {
        
        this.damage = damage;
       
       
    }
}
