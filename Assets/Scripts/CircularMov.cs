using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMov : MonoBehaviour, IMoveable
{
    private float Rotation;
    [SerializeField] private float speed = 2;
    [SerializeField] int numOfProjectiles;
    GameObject minX;
    GameObject maxX;
    GameObject minZ;
    GameObject maxZ;
    Rigidbody rb;
    float tChange = 0.0f;
    float randomX;
    float randomZ;

   
    public void Move()
    {
        if (Rotation == 360)
        {
            Rotation = 0;
        }
        Rotation = Rotation + 150 * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(Rotation, 0, Rotation);
        gameObject.transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-43, 43);
            randomZ = Random.Range(-45, 45);
            tChange = Time.time + Random.Range(5f, 10f);
        }

        Vector3 newPosition = new Vector3(randomX, 0, randomZ);
        Vector3 myPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 newDirection = (newPosition - myPosition).normalized;
        rb.velocity = newDirection * speed;
        float distance = Vector3.Distance(newPosition, myPosition);

        //if boundary is hit, change position.

        if (distance < 1)
        {
            randomX = Random.Range(-43, 43);
            randomZ = Random.Range(-45, 45);

            tChange = Time.time + Random.Range(5f, 10f);
        }



    }

    void Start()
    {

        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
}

  
