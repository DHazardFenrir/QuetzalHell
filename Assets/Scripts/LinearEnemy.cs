using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEnemy : Enemy, IMoveable
{
    [SerializeField] int healthPoint;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject minX;
    [SerializeField] GameObject m;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;
    [SerializeField] int numofProjectile;
    [SerializeField] float timeBetweenShots = 100f;
    [SerializeField] bool shotFired = false;

  


    float startTimeBetweenShots = 0.0f;
    Rigidbody rb;
   RadioBulletController rad;

    private float tChange = 0.0f; //force new direction in the first update;
   
    private float randomZ;


    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();

        
        if(rad == null)
        rad = GetComponent<RadioBulletController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }




    public override void Shoot()
    {
       if(timeBetweenShots <= 0)
        {
            rad.SpawnPorjectile(numofProjectile);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    public void Move()
    {
        if (Time.time >= tChange)
        {
          
            randomZ = Random.Range(-45, 45);

            tChange = Time.time + Random.Range(5f, 10f);
        }

        Vector3 newPosition = new Vector3(transform.position.x, 0, randomZ);
        Vector3 myPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 newDirection = (newPosition - myPosition).normalized;
        rb.velocity = newDirection * moveSpeed;
        float distance = Vector3.Distance(newPosition, myPosition);

        //if boundary is hit, change position.

        if (distance < 1)
        {
           
            randomZ = Random.Range(-45, 45);

            tChange = Time.time + Random.Range(5f, 10f);
        }

    }

    
}


