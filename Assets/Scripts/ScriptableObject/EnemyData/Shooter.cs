using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform shootOrigin;
    [SerializeField] GameObject shootPrefab;

    public void DoShoot()
    {

        Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);

    }
}

