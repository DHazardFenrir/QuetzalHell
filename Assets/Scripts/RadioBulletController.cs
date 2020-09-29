using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioBulletController : MonoBehaviour
{
    [Header("Project Settings")]
    [SerializeField] int numberOfProjectiles;
    [SerializeField] float projectilesSpeed;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject startPoint;
    [SerializeField] float rotationSpeed = 45f;

    
    
    [Header("Private Variables")]
    private const float radius = 1f;
    private Vector3 startPosition;
    private Vector3 dir = Vector3.zero;
    
    
  
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startPosition = startPoint.transform.position;
            SpawnPorjectile(numberOfProjectiles);
        }
       
       
        
    }

    private void SpawnPorjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;
        projectilePrefab.transform.rotation = Quaternion.LookRotation(dir);

        

        for(int i =0; i <= _numberOfProjectiles -1; i++)
        {
            float projectileDirXPos = startPosition.x + Mathf.Sin((angle* Mathf.PI) /180) * radius;
            float projectileDirYPos = startPosition.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            
            Vector3 projectileVector = new Vector3(projectileDirXPos, projectileDirYPos, 0);
            Vector3 projectileMoveDirection = (projectileVector- startPosition).normalized * projectilesSpeed;
            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);
                
            }

            GameObject tempObj = Instantiate(projectilePrefab,startPosition, projectilePrefab.transform.rotation );
            tempObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);
            projectilePrefab.transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
            Destroy(tempObj, 10f);
           
            angle += angleStep;
        }
    }
}
