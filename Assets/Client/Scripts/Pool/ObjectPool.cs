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

            poolDict.Add(type, objectPool);
        }
    }
    
    public T Get<T>(Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDict.ContainsKey(type) && poolDict[type].Count > 0)
        {
            IPoolable obj = poolDict[type].Dequeue();
            return (T)obj;
        }
    
        return null;
    }
    
    public void Release<T>(T poolableObject, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDict.ContainsKey(type))
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