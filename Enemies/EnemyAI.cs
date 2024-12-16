using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
  //  [SerializeField] private float speed = 2f;
  //  [SerializeField] private float rotationSpeed = 2f;
    private NavMeshAgent agent;

    private void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        

        
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            
        }
    }

    private void Update()
    {
        if (target != null)
        {
           
            agent.SetDestination(target.position);
        }
    }
}