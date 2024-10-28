﻿using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to shoot
    public Transform bulletSpawnPoint; // Where the bullet spawns
    public float bulletSpeed = 20f; // Speed of the bullet

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming Fire1 is mapped to mouse button or space
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed; // Set the bullet's velocity
        }
        else
        {
            Debug.LogError("No Rigidbody attached to bullet prefab!");
        }
    }
}