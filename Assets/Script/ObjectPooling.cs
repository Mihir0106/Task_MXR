using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}

public class ObjectPooling : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton
    public static ObjectPooling instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //Create a Dictionary for Pooling Object and Instantiate them as well 
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectpool);
        }
    }

    // Method to spawn a Object from a Pool
    public GameObject SpawnFromPool(string tag, Vector3 pos)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't Exist");
            return null;
        }

        GameObject objtoSpawn = poolDictionary[tag].Dequeue();

        objtoSpawn.SetActive(true);
        objtoSpawn.transform.position = pos;

        IPooledObject pooledObj = objtoSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null) pooledObj.OnObjectSpawn(); 

        poolDictionary[tag].Enqueue(objtoSpawn);

        return objtoSpawn;
    }

}
