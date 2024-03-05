using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    private float sessionTime = 0f; // Переменная для отслеживания времени игровой сессии
    private float initialSpawnInterval = 1f; // Изначальный интервал появления астероидов
    private float minSpawnInterval = 0.3f; // Минимальный интервал появления астероидов
    private float timeBetweenDifficultyIncrease = 15f; // Время между увеличением сложности
    private float lastDifficultyIncreaseTime = 0f; // Время последнего увеличения сложности

    private void Update()
    {
        sessionTime += Time.deltaTime; // Увеличение времени игровой сессии

        if (sessionTime - lastDifficultyIncreaseTime > timeBetweenDifficultyIncrease)
        {
            lastDifficultyIncreaseTime = sessionTime;
            initialSpawnInterval *= 0.8f; // Уменьшение изначального интервала на 20%
            if (initialSpawnInterval < minSpawnInterval)
            {
                initialSpawnInterval = minSpawnInterval; // Установка минимального интервала, если новый интервал меньше
            }
        }

        if (Time.time % initialSpawnInterval < Time.deltaTime)
        {
            AsteroidsSpace(); // Вызов метода создания астероидов с текущим интервалом
        }
    }

    private void AsteroidsSpace()
    {
        Instantiate(asteroid);
        asteroid.transform.position = new Vector3(Random.Range(-14, 1), 1, 250);
    }
}