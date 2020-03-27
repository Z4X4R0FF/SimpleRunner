using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling
{
    List<PoolObject> objects;
    Transform objectsParent;

    void AddObject(PoolObject poolObject, Transform objects_parent)
    {
        GameObject temp = GameObject.Instantiate(poolObject.gameObject);
        temp.name = poolObject.name;
        temp.transform.SetParent(objects_parent);
        objects.Add(temp.GetComponent<PoolObject>());
        temp.SetActive(false);
    }

    public void Initialize(int count, PoolObject poolObject, Transform objects_parent)
    {
        objects = new List<PoolObject>();
        objectsParent = objects_parent;
        for (int i = 0; i < count; i++)
        {
            AddObject(poolObject, objects_parent);
        }
    }

    public PoolObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].gameObject.activeInHierarchy == false)
            {
                return objects[i];
            }
        }
        AddObject(objects[0], objectsParent);
        return objects[objects.Count - 1];
    }
}
