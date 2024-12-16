using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private float groupSpawnInterval = 10f;
    [SerializeField] private int enemiesPerGroup = 5; 
    [SerializeField] private float spawnIntervalWithinGroup = 0.5f; 
    [SerializeField] private float rotationSpeed = 30f;

    private void Start()
    {
        
        StartCoroutine(SpawnEnemyGroups());
    }

    private void Update()
    {
        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private IEnumerator SpawnEnemyGroups()
    {
        while (true)
        {
            
            for (int i = 0; i < enemiesPerGroup; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnIntervalWithinGroup); 
            }

            yield return new WaitForSeconds(groupSpawnInterval); 
        }
    }

    private void SpawnEnemy()
    {
        
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

       
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
