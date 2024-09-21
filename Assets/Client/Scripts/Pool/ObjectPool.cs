// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Asteroid PrefabAsteroid;
    
    private Dictionary<Type, Queue<IPoolable>> asteroidPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();

    public void Start()
    {
        PrePool(PrefabAsteroid, 10);
    }

    public void PrePool<T>(T prefab, int count) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!asteroidPoolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            asteroidPoolDictionary.Add(type, objectPool);
        }
    }
    
    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (asteroidPoolDictionary.ContainsKey(type) && asteroidPoolDictionary[type].Count > 0)
        {
            IPoolable obj = poolDict[type].Dequeue();
            return (T)obj;
        }
    
        return null;
    }
    
    public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (asteroidPoolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = poolDict[type];
            objectPool.Enqueue(poolableObject);
            poolableObject.OnRelease();
        }
    }
    
    public Asteroid GetAsteroid()
    {
        return Get<Asteroid>(asteroidPoolDictionary);
    }

    public void ReleaseAsteroid(Asteroid asteroid)
    {
        Release(asteroid, asteroidPoolDictionary);
    }
}