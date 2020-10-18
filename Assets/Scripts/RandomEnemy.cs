using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class RandomEnemy : Enemy, IMoveable
{
    [SerializeField] int healthPoint;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject minX;
    [SerializeField] GameObject maxX;
    [SerializeField] GameObject minZ;
    [SerializeField] GameObject maxZ;
    Rigidbody rb;

    private float tChange = 0.0f; //force new direction in the first update;
    private float randomX;
    private float randomZ;


    // Start is called before the first frame update
    void Start()
    {
        minX = GameManager.Instance.leftBoundary;
        maxX = GameManager.Instance.rightBoundary;
        minZ = GameManager.Instance.bottomBoundary;
        maxZ = GameManager.Instance.topBoundary;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

   
    

    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        if(Time.time >= tChange)
        {
            randomX = Random.Range(-43, 43);
            randomZ = Random.Range(-45,45);

            tChange = Time.time + Random.Range(5f, 10f);
        }

        Vector3 newPosition = new Vector3(randomX, 0, randomZ);
        Vector3 myPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 newDirection = (newPosition - myPosition).normalized;
        rb.velocity = newDirection * moveSpeed;
        float distance = Vector3.Distance(newPosition, myPosition);
       
        //if boundary is hit, change position.

        if(distance < 1)
        {
            randomX = Random.Range(-43, 43);
            randomZ = Random.Range(-45, 45);

            tChange = Time.time + Random.Range(5f, 10f);
        }

        //Vector3 clampedPosition = transform.position;
        //clampedPosition.x = Mathf.Clamp(transform.position.x, minX.transform.position.x, maxX.transform.position.x);
        //clampedPosition.z = Mathf.Clamp(transform.position.z, minX.transform.position.z, maxX.transform.position.z);
        //transform.position = clampedPosition;
    }

    
}
