// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Asteroid : MonoBehaviour, IPoolable
{
    public float _asteroidSpeed = 5f;
    public float rotationSpeed = 30f;
    
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
    }

    public void Update()
    {
        _asteroidSpeed -= 0.15f;
        transform.Translate(0, 0, _asteroidSpeed);
        rb.AddTorque(transform.forward * rotationSpeed);
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
        // if (other.CompareTag("Spaceship"))
        // {
            // Spaceship spaceship = other.GetComponent<Spaceship>();
            // spaceship.health -= 20;
            // if (spaceship.health <= 0)
            // {
                // spaceship.OnRelease();
            // }
        // }
    
    // public void OnRelease()
    // {
        // gameObject.SetActive(false);
    // }
}