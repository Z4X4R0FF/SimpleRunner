using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSetup : MonoBehaviour
{
    [SerializeField]
    private PoolManager.PoolPart[] pools;
    void OnValidate()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].name = pools[i].prefab.name;
        }
    }

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        PoolManager.Initialize(pools);
    }

}
