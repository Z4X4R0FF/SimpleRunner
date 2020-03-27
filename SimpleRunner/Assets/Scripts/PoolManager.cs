using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    private static PoolPart[] pools;
    private static GameObject objectsParent;
    [System.Serializable]
    public struct PoolPart
    {
        public string name;
        public PoolObject prefab;
        public int count;
        public ObjectPooling poolGroup;
    }
    public static void Initialize(PoolPart[] newPools)
    {
        pools = newPools;
        objectsParent = new GameObject();
        objectsParent.name = "Pool";
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].prefab != null)
            {
                pools[i].poolGroup = new ObjectPooling();
                pools[i].poolGroup.Initialize(pools[i].count, pools[i].prefab, objectsParent.transform);
            }
        }
    }

    public static GameObject GetObject(string name, Vector3 position, Quaternion rotation)
    {
        GameObject result = null;
        if (pools != null)
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (string.Compare(pools[i].name, name) == 0)
                {
                    result = pools[i].poolGroup.GetObject().gameObject;
                    result.transform.position = position;
                    result.transform.rotation = rotation;
                    result.SetActive(true);
                    return result;
                }
            }
        }
        return result;
    }
}
