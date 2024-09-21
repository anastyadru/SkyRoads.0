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

    public void Update()
    {
		if (asteroidSpeed > 0)
        {
			asteroidSpeed -= 0.15f * Time.deltaTime;
        	transform.Translate(0, 0, _asteroidSpeed);
        	rb.AddTorque(transform.forward * rotationSpeed);
		}
    }

	public void OnRelease()
    {
        // Логика очистки или сброса состояния астероида
        _asteroidSpeed = 0; // Например, сброс скорости
        transform.position = Vector3.zero; // Например, сброс позиции
        rb.velocity = Vector3.zero; // Сброс скорости Rigidbody
        rb.angularVelocity = Vector3.zero; // Сброс угловой скорости
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