using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject projectilePrefab;     // The projectile that will be fired
    public Transform firePoint;             // The point from which the projectile will be shot
    public float projectileSpeed = 20f;     // Speed of the projectile
    public float fireRate = 1f;             // Time between each shot

    private float nextFireTime = 0f;

    void Update()
    {
        // Check if it's time to shoot and the player has clicked the mouse button
        if (Time.time >= nextFireTime && Input.GetMouseButtonDown(0))  // Left Mouse Button (0)
        {
            Shoot();  // Shoot from the turret
            nextFireTime = Time.time + 1f / fireRate;  // Set the time for the next shot
        }
    }

    // Shoots a projectile from the firePoint
    void Shoot()
    {
        // Instantiate the projectile at the fire point's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Apply velocity to the projectile in the forward direction
        rb.velocity = firePoint.forward * projectileSpeed;
    }
}
