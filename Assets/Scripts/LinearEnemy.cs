using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEnemy : Enemy, IMoveable
{
   
    [SerializeField] float moveSpeed;
  
    [SerializeField] GameObject minZ;
    [SerializeField] GameObject maxZ;
    
    [SerializeField] float timeBetweenShots;

    [SerializeField] bool canShoot;
     
  


  
    Rigidbody rb;


    private float tChange = 0.0f; //force new direction in the first update;
   
    private float randomZ;


    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();

        minZ = GameManager.Instance.secondBottomBounday;
        maxZ = GameManager.Instance.secondTopBounday;

        canShoot = false;


     
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Move();
        if (canShoot && timeBetweenShots > 0)
            Shoot();

        timeBetweenShots -= Time.deltaTime;

        if (timeBetweenShots <= 0)
        {
            canShoot = false;
            timeBetweenShots = 100f;
        }
         
        

    }




   

    public void Move()
    {
        if (Time.time >= tChange)
        {
          
            randomZ = Random.Range(minZ.transform.position.z, maxZ.transform.position.z);

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
           
            randomZ = Random.Range(minZ.transform.position.z, maxZ.transform.position.z);

            tChange = Time.time + Random.Range(5f, 10f);
        }

    }

   


}


