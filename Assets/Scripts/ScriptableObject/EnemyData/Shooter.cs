using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform shootOrigin;
    [SerializeField] GameObject shootPrefab;
    [SerializeField] private ShootingConfig config;
    public ShootingConfig shootingConfig
    {

        get
        {
            return config;
        }
    }

    private void Start()
    {
        if (config == null)
            return;

        if (config.autoShooting)
        {
            StartCoroutine(AutoShoot());
        }
    }

    private IEnumerator AutoShoot()
    {
        while (true)
        {
            DoShoot();
            yield return new WaitForSeconds(config.shootCadence);
        }
    }
    public bool isEnabled = true;
    public void DoShoot()
    {
        if (isEnabled && shootOrigin != null)
            Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);

    }

    public void EnableShooter(bool shouldEnable)
    {
        isEnabled = shouldEnable;
    }
}

