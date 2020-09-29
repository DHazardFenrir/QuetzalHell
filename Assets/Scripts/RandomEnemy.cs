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
            randomX = Random.Range(-46,46);
            randomZ = Random.Range(-46,46);

            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }

        Vector3 newPosition = new Vector3(randomX, 0, randomZ);
        transform.Translate(newPosition * moveSpeed * Time.deltaTime);

        //if boundary is hit, change position.

        if(transform.position.x >= maxX.transform.position.x || transform.position.x <= minX.transform.position.x)
        {
            randomX = -randomX;
        }

      

        if (transform.position.z >= maxZ.transform.position.z || transform.position.z <= minZ.transform.position.z)
        {
            randomZ = -randomZ;
        }

        //Vector3 clampedPosition = transform.position;
        //clampedPosition.x = Mathf.Clamp(transform.position.x, minX.transform.position.x, maxX.transform.position.x);
        //clampedPosition.z = Mathf.Clamp(transform.position.z, minX.transform.position.z, maxX.transform.position.z);
        //transform.position = clampedPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == GameManager.Instance.rightBoundary || collision.gameObject == GameManager.Instance.leftBoundary)
        {
            randomX = -randomX;
        }

        if(collision.gameObject == GameManager.Instance.topBoundary || collision.gameObject == GameManager.Instance.bottomBoundary)
        {
            randomZ = -randomZ;
        }
    }
}
