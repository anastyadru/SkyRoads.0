// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public float _asteroidSpeed;
    public float rotationSpeed = 30f;

    public void Update()
    {
        _asteroidSpeed -= 0.15f;
        transform.Translate(0, 0, _asteroidSpeed);
        GetComponent<Rigidbody>().AddTorque(transform.forward * rotationSpeed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            Spaceship spaceship = other.GetComponent<Spaceship>();
            spaceship.health -= 20;
            if (spaceship.health <= 0)
            {
                spaceship.OnRelease();
            }
        }
    }
    
    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}