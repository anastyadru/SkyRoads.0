// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Asteroid PrefabAsteroid;
    
    public Dictionary<Type, Queue<IPoolable>> asteroidPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();

    public void Start()
    {
        PrePool<Asteroid>(PrefabAsteroid, 15, asteroidPoolDictionary);
    }

    public void PrePool<T>(T prefab, int count, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {

    }
}