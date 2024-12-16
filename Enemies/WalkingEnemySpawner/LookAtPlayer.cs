using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private float angleThreshold = 90f; 

    private void Start()
    {
        
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            
        }
    }

    private void Update()
    {
        if (player == null) return;

        
        Vector3 playerForward = player.forward;

        
        Vector3 toPlayer = (player.position - transform.position).normalized;

        
        playerForward.y = 0;
        toPlayer.y = 0;

        
        float angleToPlayer = Vector3.Angle(playerForward, -toPlayer);

        
        if (angleToPlayer > angleThreshold)
        {
            
            Quaternion targetRotation = Quaternion.LookRotation(toPlayer);

           
            transform.rotation = targetRotation;
        }
    }
}
