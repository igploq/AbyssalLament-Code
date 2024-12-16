using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathHighscore : MonoBehaviour
{
    [SerializeField] private Text highscoreText; 

    private void Start()
    {
        
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            highscoreText.text = " " + scoreManager.GetHighscore();
        }
    }
}
