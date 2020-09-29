using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject minX;
    [SerializeField] GameObject maxX;
    [SerializeField] GameObject minZ;
    [SerializeField] GameObject maxZ;
    [SerializeField]int  enemyCount;

    private float xPos;
    private float zPos;
    private float randomX;
    private float randomZ;
    // Start is called before the first frame update
    void Start()
    {
        minX = GameManager.Instance.leftBoundary;
        maxX = GameManager.Instance.rightBoundary;
        minZ = GameManager.Instance.bottomBoundary;
        maxZ = GameManager.Instance.topBoundary;
        StartCoroutine(EnemyDrop());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            randomX = Random.Range(minX.transform.position.x, maxX.transform.position.x);
            randomZ = Random.Range(minZ.transform.position.z, maxX.transform.position.z);
            
            Instantiate(enemy, new Vector3(randomX, 0, randomZ), Quaternion.identity);
            yield return new WaitForSeconds(.01f);
            enemyCount++;
        }
    }
}
