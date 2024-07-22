// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float normalSpeed = 3f;
    public float boostedSpeed = 10f;
    private float moveSpeed;
    private float rotationX = 0f;
    
    public int health = 100;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed = boostedSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            moveSpeed = normalSpeed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 1)
            {
                transform.position += new Vector3(0.8f, 0, 0);
                rotationX = Mathf.Lerp(rotationX, -50f, Time.deltaTime * rotationSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -14)
            {
                transform.position += new Vector3(-0.8f, 0, 0);
                rotationX = Mathf.Lerp(rotationX, 50f, Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            rotationX = Mathf.Lerp(rotationX, 0f, Time.deltaTime * rotationSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, rotationX);
    }
    
    // public void OnRelease()
    // {
        // gameObject.SetActive(false);
    // }
}