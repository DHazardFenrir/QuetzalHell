using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform myShotPoint;
    [SerializeField] Rigidbody bulletRb;
    [SerializeField] float bulletSpeed;
    Rigidbody bulletInstance;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
         bulletInstance = Instantiate(bulletRb, myShotPoint.position, myShotPoint.rotation);
        bulletInstance.velocity = Vector3.forward * bulletSpeed;
    }
}
