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

    public float score;
    public float highscore;
    public float normalSpeed = 1f;
    public float boostedSpeed = 2f;
    public int asteroidScore = 5;

    private bool isBoosted = false;

    public void Start()
    {
        score = 0;
        StartCoroutine(UpdateScore());
    }

    public void Update()
    {
        HighScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("score").ToString();
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            if (isBoosted)
            {
                score += boostedSpeed * 2;
            }
            else
            {
                score += normalSpeed;
            }

            ScoreText.text = "SCORE: " + Mathf.RoundToInt(score).ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    public void AddAsteroidScore()
    {
        score += asteroidScore;
    }

    public void ToggleBoostedSpeed(bool isBoosted)
    {
        this.isBoosted = isBoosted;
    }

    private void OnDisable()
    {
        if (PlayerPrefs.GetInt("score") <= Mathf.RoundToInt(score))
        {
            PlayerPrefs.SetInt("score", Mathf.RoundToInt(score));
        }
    }
}