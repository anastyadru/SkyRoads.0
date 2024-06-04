// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        StartCoroutine(UpdateScore());
    }

    public void Update()
    {
        HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            if (isBoosted)
            {
                score += Mathf.RoundToInt(boostedSpeed * 2);
            }
            else
            {
                score += Mathf.RoundToInt(normalSpeed);
            }

            ScoreText.text = "SCORE: " + score.ToString();

            if (score > highscore)
            {
                highscore = score;
                HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
            }
            
            yield return new WaitForSeconds(1f);
        }
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