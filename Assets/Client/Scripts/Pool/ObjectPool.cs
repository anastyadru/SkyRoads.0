// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Asteroid PrefabAsteroid;
    
    private Dictionary<Type, Queue<IPoolable>> asteroidPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    
    public int initialPoolSize = 10;
    public int maxPoolSize = 30;

    public void Start()
    {
        PrePool<PrefabAsteroid>(prefabAsteroid, initialPoolSize, asteroidPoolDictionary);
    }

    public void PrePool<T>(T prefab, int count, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!poolDict.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(type, objectPool);
        }
    }
    
    public T Get<T>(Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDict.ContainsKey(type))
        {
            if (poolDict[type].Count == 0)
            {
                if (poolDict[type].Count < maxPoolSize)
                {
                    T prefab = null;
                    if (type == typeof(PrefabAsteroid)) prefab = prefabAsteroid as T;

                    if (prefab != null)
                    {
                        PrePool(prefab, 1, poolDict);
                    }
                }
            }

            if (poolDict[type].Count > 0)
            {
                IPoolable obj = poolDict[type].Dequeue();
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