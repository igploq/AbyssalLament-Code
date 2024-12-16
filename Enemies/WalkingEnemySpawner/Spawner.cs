using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int HP = 100;

    public event Action<Transform> OnDestroyed;

    private Transform spawnPoint; 

    public void SetSpawnPoint(Transform point)
    {
        spawnPoint = point;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        

        if (HP <= 0)
        {
            
            OnDestroyed?.Invoke(spawnPoint); 
            Destroy(gameObject);
        }
    }
}

