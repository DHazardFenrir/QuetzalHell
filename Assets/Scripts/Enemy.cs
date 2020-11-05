using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour, IDamageable
{
    [SerializeField] float healthPoints;
    [SerializeField] int featherPoints;
  
    public RadioBulletController rad;
    [SerializeField] int shots;
    // Start is called before the first frame update
    void Start()
    {
        rad = GetComponent<RadioBulletController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

  

    public void Damage(int amount)
    {
        healthPoints -= amount;
        Debug.Log("its recieving damage");     

        if(healthPoints <= 0)
        {
            Destroy(this.gameObject);
            GameManager.Instance.points += featherPoints;
        }
    }

    public void Shoot()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(10f);
        rad.SpawnPorjectile(shots);
    }
}
