using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyWaves> wavesConfigs;
    //public List<Transform> spawnPoints;


    [SerializeField] Quaternion spawnRotation;


    [SerializeField] float initialWaitTime;
    [SerializeField] float candaceBetweenWaves;

    private void Start()
    {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    public void SpawnEnemy(EnemyController enemyPrefab, EnemyConfig config, Vector3 enemyPosition, Quaternion rotation)
    {

        var enemyInstantiate = Instantiate(enemyPrefab, enemyPosition, rotation);
        enemyInstantiate.config = config;



    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);
        foreach (var wave in wavesConfigs)
        {

            foreach (var enemy in wave.enemies)
            {
                Vector3 enemyPosition;
                if (enemy.useSpecificXPosition)
                {

                    enemyPosition = enemy.spawnReferencePosition;
                }
                else
                {
                    enemyPosition = new Vector3(Random.Range(-enemy.spawnReferencePosition.x, enemy.spawnReferencePosition.x), enemy.spawnReferencePosition.y, enemy.spawnReferencePosition.z);
                }
                SpawnEnemy(enemy.enemyPrefab, enemy.config, enemyPosition, spawnRotation);
                yield return new WaitForSeconds(wave.cadence);
            }
            yield return new WaitForSeconds(candaceBetweenWaves);
        }
    }
}
