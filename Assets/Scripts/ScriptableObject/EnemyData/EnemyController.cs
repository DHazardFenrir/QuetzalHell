using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public EnemyConfig config;
    private Mover mover;

    [SerializeField] private GameObject meshRenderer;
    private Shooter[] shooters;

    private void Start()
    {
        mover = GetComponent<Mover>();
        if (mover != null)
        {
            mover.speed = config.moveSpeed;
        }

        if (config.prefab != null)
        {
            meshRenderer = config.prefab;
        }

        if (config.isShooter)
        {
            shooters = GetComponentsInChildren<Shooter>();
            if (shooters != null && shooters.Length > 0)
            {
                foreach (var shooter in shooters)
                {
                    StartCoroutine(shootForever());
                }

            }
        }




    }

    private IEnumerator shootForever()
    {
        yield return new WaitForSeconds(config.shootInitialWaitTime);
        while (true)
        {
            foreach (var shooter in shooters)
            {
                shooter.DoShoot();
            }
            yield return new WaitForSeconds(config.shootCandance);
        }

    }
}
