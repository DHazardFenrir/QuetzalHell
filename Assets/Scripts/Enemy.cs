using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy: MonoBehaviour, IDamageable
{
    [SerializeField] float initialHealthPoints;
    [SerializeField] int featherPoints;
    [SerializeField] int shots;
    [SerializeField] Image healthBar;

    private float currentHealthPoints;

    public RadioBulletController rad;

    private void Awake()
    {
        currentHealthPoints = initialHealthPoints;
    }

    void Start()
    {
        //rad = GetComponent<RadioBulletController>();
    }

    void Update()
    {
        Shoot();
    }

    public void Damage(int amount)
    {
        currentHealthPoints -= amount;
        Debug.Log("its recieving damage");

        healthBar.fillAmount = (currentHealthPoints / initialHealthPoints);

        if(currentHealthPoints <= 0)
        {
            GameManager.Instance.points += featherPoints;
            Destroy(this.gameObject);
        }
    }

    public void Shoot()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(10f);
        //rad.SpawnPorjectile(shots);
    }
}
