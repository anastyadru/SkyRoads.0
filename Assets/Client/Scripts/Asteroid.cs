// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Asteroid : MonoBehaviour, IPoolable
{
    public float _asteroidSpeed;
    public float rotationSpeed = 30f;
    
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
		if (asteroidSpeed > 0)
        {
			_asteroidSpeed -= 0.15f * Time.deltaTime;
        	transform.Translate(0, 0, _asteroidSpeed * Time.deltaTime);
        	rb.AddTorque(transform.forward * rotationSpeed * Time.deltaTime);
		}
    }

	public void OnRelease()
    {
        _asteroidSpeed = 0;
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