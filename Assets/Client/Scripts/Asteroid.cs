// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}