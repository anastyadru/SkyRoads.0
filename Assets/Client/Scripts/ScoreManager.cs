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
    public float normalSpeed = 1f; // Скорость полета на обычной скорости
    public float boostedSpeed = 2f; // Скорость полета в режиме ускорения
    public int asteroidScore = 5; // Очки за пройденный астероид

    private bool isBoosted = false; // Флаг, указывающий на нахождение в режиме ускорения

    void Start()
    {
        score = 0;
        StartCoroutine(UpdateScore()); // Запускаем корутину для обновления очков каждую секунду
    }

    void Update()
    {
        HighScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("score").ToString();
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            if (isBoosted)
            {
                score += boostedSpeed * 2; // Увеличиваем очки в режиме ускорения в два раза
            }
            else
            {
                score += normalSpeed; // Увеличиваем очки на обычной скорости
            }

            ScoreText.text = "SCORE: " + Mathf.RoundToInt(score).ToString(); // Округляем и отображаем очки на экране

            yield return new WaitForSeconds(1f); // Ждем 1 секунду перед следующим обновлением очков
        }
    }

    public void AddAsteroidScore()
    {
        score += asteroidScore; // Добавляем очки за пройденный астероид
    }

    public void ToggleBoostedSpeed(bool isBoosted)
    {
        this.isBoosted = isBoosted; // Включаем или выключаем режим ускорения
    }

    private void OnDisable()
    {
        if (PlayerPrefs.GetInt("score") <= Mathf.RoundToInt(score))
        {
            PlayerPrefs.SetInt("score", Mathf.RoundToInt(score)); // Сохраняем новый рекорд в PlayerPrefs
        }
    }
}