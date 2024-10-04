// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Asteroid PrefabAsteroid;
    
    private Dictionary<Type, Queue<IPoolable>> asteroidPoolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    private int initialPoolSize = 10;
    private int maxPoolSize = 30;

    public void Start()
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
        }
    }
    
    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (asteroidPoolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = asteroidPoolDictionary[type];
            if (objectPool.Count > 0)
            {
                IPoolable obj = objectPool.Dequeue();
                return (T)obj;
            }
            else
            {
                // Если объектов не осталось, создаем новые до максимального размера пула
                if (objectPool.Count + initialPoolSize <= maxPoolSize)
                {
                    PrePool(Activator.CreateInstance<T>(), initialPoolSize);
                    return Get<T>(); // Попробуем снова получить объект после создания новых
                }
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