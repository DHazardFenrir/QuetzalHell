using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEnemy : Enemy, IMoveable
{
    [SerializeField] int healthPoint;
    [SerializeField] float moveSpeed;

    [SerializeField] GameObject minZ;
    [SerializeField] GameObject maxZ;
    private Rigidbody rb;

    [SerializeField] bool maxChangeZ;
    [SerializeField] bool minChangeZ;
    private float randomZ;

    private float tChange = 0.0f; //force new direction in the first update;



    // Start is called before the first frame update
    void Start()
    {

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
        if (Time.time >= tChange)
        {



            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }


        //if boundary is hit, change position.



        if (transform.position.z >= maxZ.transform.position.z)
        {
            rb.velocity = Vector3.back * moveSpeed;
            maxChangeZ = true;
        }
        else if (transform.position.z >= minZ.transform.position.z)
        {
            rb.velocity = Vector3.forward * moveSpeed;
            minChangeZ = true;
            maxChangeZ = false;
        }

        //Vector3 clampedPosition = transform.position;
        //clampedPosition.x = Mathf.Clamp(transform.position.x, minX.transform.position.x, maxX.transform.position.x);
        //clampedPosition.z = Mathf.Clamp(transform.position.z, minX.transform.position.z, maxX.transform.position.z);
        //transform.position = clampedPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == GameManager.Instance.topBoundary)
        {
            Debug.Log("Estoy colisionando con el limite derecho");
            rb.velocity = Vector3.back * moveSpeed;

        }
        else if (collision.gameObject == GameManager.Instance.bottomBoundary)
        {
            Debug.Log("Estoy colisionando con el limite izquierdo");
            rb.velocity = Vector3.forward * moveSpeed;



        }
    }
}


