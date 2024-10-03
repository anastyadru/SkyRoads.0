// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float normalSpeed = 3f;
    public float boostedSpeed = 10f;
    private float moveSpeed;
    private float rotationX = 0f;
    
    public int health = 100;

    private Rigidbody rb;
    public void Update()
    {
        HandleBoostInput();
        HandleMovementInput();
        ApplyRotation();
    }

    private void HandleBoostInput()
    {
        moveSpeed = Input.GetKey(KeyCode.Space) ? boostedSpeed : normalSpeed;
    }

    private void HandleMovementInput()
    {
        float moveDirection = Input.GetKey(KeyCode.D) ? 0.8f : Input.GetKey(KeyCode.A) ? -0.8f : 0f;
        if (transform.position.x + moveDirection > -14 && transform.position.x + moveDirection < 1)
        {
            transform.position += new Vector3(moveDirection, 0, 0);
            rotationX = Mathf.Lerp(rotationX, moveDirection * -50f, Time.deltaTime * rotationSpeed);
        }
    }

    private void ApplyRotation()
    {
        rotationX = Mathf.Lerp(rotationX, 0f, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, 0, rotationX);
    }
    
    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}