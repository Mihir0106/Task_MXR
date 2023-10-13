using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    ObjectPooling objectPooling;

    void Start()
    {
        if (ObjectPooling.instance != null)
            objectPooling = ObjectPooling.instance;
        else
            Debug.LogError("Pool Doesn't Exist");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = objectPooling.SpawnFromPool("Bullet", bulletSpawnPoint.position);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

    }
}
