using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private float groupSpawnInterval = 10f; 
    [SerializeField] private int enemiesPerGroup = 5; 
    [SerializeField] private float spawnIntervalWithinGroup = 0.5f; 
    [SerializeField] private Rigidbody rb; 

    private bool hasLanded = false; 

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!hasLanded && collision.gameObject.CompareTag("Wall"))
        {
            hasLanded = true;
            rb.isKinematic = true;
            StartCoroutine(SpawnEnemyGroups()); 
        }
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