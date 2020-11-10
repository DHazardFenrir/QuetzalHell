using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform myShotPoint;
    [SerializeField] GameObject bulletPrefab;
   

    public float timeBetweenShoot;
    private float TimeOfLastShoot;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        { if(Time.time > TimeOfLastShoot - timeBetweenShoot)
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, myShotPoint.position, myShotPoint.rotation);
        TimeOfLastShoot = Time.time;
    }
       
}
