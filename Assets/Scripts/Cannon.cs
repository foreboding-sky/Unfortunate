using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ParticleSystem shootEffect;
    [SerializeField] private float bulletSpeed = 12f;
    [SerializeField] private float cooldown = 1f;
    private bool cannonReloaded;
    void Start()
    {
        cannonReloaded = true;
    }
    void Update()
    {
        if (cannonReloaded)
        {
            StartCoroutine(_TriggerSpikes());
        }
    }
    IEnumerator _TriggerSpikes()
    {
        cannonReloaded = false;
        BulletShoot();
        yield return new WaitForSeconds(cooldown);
        cannonReloaded = true;
    }
    private void BulletShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(90f, 0f, 0f));
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = bulletSpeed * bulletSpawnPoint.forward;
    }
}
