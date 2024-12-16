using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText; 
    [SerializeField] private int pointsPerSecond = 3; 

    private float score; 
    private int highscore = 0;

    private void Update()
    {
        
        score += pointsPerSecond * Time.deltaTime;

        
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void SaveHighscore()
    {
        
        if (score > highscore)
        {
            highscore = Mathf.FloorToInt(score);
        }
    }

    public int GetHighscore()
    {
        return highscore;
    }
}