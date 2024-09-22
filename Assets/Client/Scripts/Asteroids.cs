// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;

    private float sessionTime;
    private float initialSpawnInterval = 1f;
    private float minSpawnInterval = 0.3f;
    private float timeBetweenDifficultyIncrease = 15f;
    private float lastDifficultyIncreaseTime;

    private void Update()
    {
        sessionTime += Time.deltaTime;
        if (sessionTime - lastDifficultyIncreaseTime > timeBetweenDifficultyIncrease)
        {
            lastDifficultyIncreaseTime = sessionTime;
            initialSpawnInterval *= 0.8f;
            initialSpawnInterval = Mathf.Max(initialSpawnInterval, minSpawnInterval);
        }
        if (Time.time % initialSpawnInterval < Time.deltaTime)
        {
            CreateAsteroid();
        }
    }

    private void CreateAsteroid()
    {
        GameObject newAsteroid = Instantiate(asteroid);
        newAsteroid.transform.position = new Vector3(Random.Range(-14, 1), 1, 250);
    }
}