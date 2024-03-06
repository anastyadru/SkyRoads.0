using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    
    private float sessionTime = 0f;
    private float initialSpawnInterval = 1f;
    private float minSpawnInterval = 0.3f;
    private float timeBetweenDifficultyIncrease = 15f;
    private float lastDifficultyIncreaseTime = 0f;

    private void Update()
    {
        sessionTime += Time.deltaTime;
        if (sessionTime - lastDifficultyIncreaseTime > timeBetweenDifficultyIncrease)
        {
            lastDifficultyIncreaseTime = sessionTime;
            initialSpawnInterval *= 0.8f;
            if (initialSpawnInterval < minSpawnInterval)
            {
                initialSpawnInterval = minSpawnInterval;
            }
        }
        if (Time.time % initialSpawnInterval < Time.deltaTime)
        {
            AsteroidsSpace();
        }
    }

    private void AsteroidsSpace()
    {
        Instantiate(asteroid);
        asteroid.transform.position = new Vector3(UnityEngine.Random.Range(-14, 1), 1, 250);
    }
}