// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Asteroid : MonoBehaviour, IPoolable
{
    public float asteroidSpeed;
    public float rotationSpeed = 30f;
    
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void FixedUpdate()
    {
		rb.MovePosition(rb.position + new Vector3(0f, 0f, asteroidSpeed);
		rb.AddTorque(transform.forward * rotationSpeed);
	}

    public void Update()
    {
		asteroidSpeed -= 0.15f;
        // transform.Translate(0, 0, asteroidSpeed);
        // rb.AddTorque(transform.forward * rotationSpeed);
    }

	public void OnRelease()
    {
        asteroidSpeed = 0;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
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