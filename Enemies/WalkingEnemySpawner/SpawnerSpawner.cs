using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnerPrefabs; 
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private float spawnInterval = 5f; 
    private List<Transform> busyPoints = new List<Transform>(); 
    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnSpawner();
            spawnTimer = 0f;
        }
    }

    private void SpawnSpawner()
    {
        
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        availablePoints.RemoveAll(point => busyPoints.Contains(point));

        

        
        Transform spawnPoint = availablePoints[Random.Range(0, availablePoints.Count)];

        
        GameObject randomSpawnerPrefab = spawnerPrefabs[Random.Range(0, spawnerPrefabs.Length)];

        
        GameObject newSpawner = Instantiate(randomSpawnerPrefab, spawnPoint.position, spawnPoint.rotation);
        busyPoints.Add(spawnPoint);

        

        
        Spawner spawner = newSpawner.GetComponent<Spawner>();
        if (spawner != null)
        {
            spawner.OnDestroyed += FreePoint;
            spawner.SetSpawnPoint(spawnPoint); 
        }
        
    }

    private void FreePoint(Transform freedPoint)
    {
        if (busyPoints.Contains(freedPoint))
        {
            busyPoints.Remove(freedPoint);
            
        }
        
    }
}
