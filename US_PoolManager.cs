using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_PoolManager : MonoBehaviour
{
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

    static US_PoolManager _instance;

    public static US_PoolManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<US_PoolManager>();
            }
            return _instance;
        }
    }

    public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());
            for (int i = 0; i < poolSize; i++)
            {
                GameObject spawnedObject = Instantiate(prefab) as GameObject;
                spawnedObject.SetActive(false);
                poolDictionary[poolKey].Enqueue(spawnedObject);
                spawnedObject.transform.parent = transform;
            }
        }
    }

    public void ActivatePoolObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        if (poolDictionary.ContainsKey(poolKey))
        {
            GameObject objectToActivate = poolDictionary[poolKey].Dequeue();
            poolDictionary[poolKey].Enqueue(objectToActivate);
            objectToActivate.SetActive(true);
            objectToActivate.transform.position = position;
            objectToActivate.transform.rotation = rotation;           
        }
    }

}
