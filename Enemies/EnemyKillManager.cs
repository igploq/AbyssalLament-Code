using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillManager : MonoBehaviour
{
    [SerializeField] private AudioSource track; 
    private bool isTrackPlayed = false; 

    public void OnEnemyKilled()
    {
        if (!isTrackPlayed) 
        {
            track.Play(); 
            isTrackPlayed = true; 
        }
    }
}
