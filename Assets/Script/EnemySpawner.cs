using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 0.75f;
    private float nextSpawnTime = 0.0f;

    ObjectPooling objectPooling;

    void Start()
    {
        if (ObjectPooling.instance != null)
            objectPooling = ObjectPooling.instance;
        else
            Debug.LogError("Pool Doesn't Exist");
    }

    private void FixedUpdate()
    {
        if (Time.time >= nextSpawnTime)
        {
            objectPooling.SpawnFromPool("Enemy", new Vector3(Random.Range(-2, 2), Random.Range(2, 4), transform.position.z));
            
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

}
