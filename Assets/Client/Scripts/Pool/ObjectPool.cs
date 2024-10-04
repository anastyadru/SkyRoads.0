// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Asteroid PrefabAsteroid;
    
    private Dictionary<Type, Queue<IPoolable>> asteroidPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    private Dictionary<Type, int> poolSizes = new Dictionary<Type, int>();

    public int initialPoolSize = 10;
    public int maxPoolSize = 30;
    public int increaseAmount = 10;

    void Start()
    {
        PrePool(PrefabAsteroid, initialPoolSize);
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
            poolSizes.Add(type, count);
        }
    }
    
    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        
        if (asteroidPoolDictionary.ContainsKey(type))
        {
            if (asteroidPoolDictionary[type].Count == 0)
            {
                if (poolSizes[type] < maxPoolSize)
                {
                    int toAdd = Math.Min(maxPoolSize - poolSizes[type], increaseAmount);
                    PrePool(Instantiate(PrefabAsteroid), toAdd);
                }
            }

            if (asteroidPoolDictionary[type].Count > 0)
            {
                IPoolable obj = asteroidPoolDictionary[type].Dequeue();
                obj.gameObject.SetActive(true);
                return (T)obj;
            }
        }

        return null;
    }
    
    public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (asteroidPoolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = asteroidPoolDictionary[type];
            objectPool.Enqueue(poolableObject);
            poolableObject.OnRelease();
            poolableObject.gameObject.SetActive(false);
        }
    }
    
    public Asteroid GetAsteroid()
    {
        return Get<Asteroid>();
    }

    public void ReleaseAsteroid(Asteroid asteroid)
    {
        Release(asteroid);
    }
}