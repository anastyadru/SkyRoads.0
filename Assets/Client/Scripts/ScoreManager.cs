// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;
    [SerializeField] private Text ScoreText;

    public int score;
    public int highscore;
    
    public float normalSpeed = 1f;
    public float boostedSpeed = 2f;
    public int asteroidScore = 5;

    private bool isBoosted = false;
    private int prevHighscore;

    public void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        prevHighscore = highscore;
        StartCoroutine(UpdateScore());
        UpdateHighScoreText();
    }

    public void Update()
    {
        
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            score += isBoosted ? Mathf.RoundToInt(boostedSpeed * 2) : Mathf.RoundToInt(normalSpeed);
            ScoreText.text = "SCORE: " + score.ToString();

            if (score > highscore)
            {
                highscore = score;
                UpdateHighScoreText();
            }
            
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateHighScoreText()
    {
        HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
        prevHighscore = highscore;
    }
    
    public void AddAsteroidScore()
    {
        score += asteroidScore;
    }

    public void ToggleBoostedSpeed(bool newIsBoosted)
    {
        isBoosted = newIsBoosted;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }
}