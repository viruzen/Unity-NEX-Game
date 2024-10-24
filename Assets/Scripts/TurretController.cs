using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public List<GameObject> turrets;         // List of turrets attached to the player
    public GameObject projectilePrefab;      // The projectile to shoot
    public float projectileSpeed = 20f;      // Speed of the projectile
    public float fireRate = 1f;              // Shots per second for each turret
    public Transform target;                 // Target for the turrets (optional, use for turret rotation)
    public float rotationSpeed = 5f;         // Speed at which the turrets rotate toward the target

    private float nextFireTime = 0f;

    void Update()
    {
        // Check if it's time to shoot based on the fire rate and if the mouse button is clicked
        if (Time.time >= nextFireTime && Input.GetMouseButtonDown(0))  // Fire on left-click (Mouse button 0)
        {
            ShootFromTurrets();
            nextFireTime = Time.time + 1f / fireRate;  // Calculate time for the next shot
        }
    }

    // Shoots from only the first 2 turrets in the list
    void ShootFromTurrets()
    {
        int turretsToShoot = Mathf.Min(2, turrets.Count);  // Limit to 2 turrets max

        for (int i = 0; i < turretsToShoot; i++)
        {
            GameObject turret = turrets[i];
            Transform firePoint = turret.transform;  // Assuming firePoint is the turret's position

            if (target != null)
            {
                RotateTurret(turret, target);
            }

            // Shoot from the turret's firePoint
            Shoot(firePoint);
        }
    }

    // Rotates the turret to face the target
    void RotateTurret(GameObject turret, Transform target)
    {
        Vector3 direction = (target.position - turret.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    // Instantiate and shoot a projectile
    void Shoot(Transform firePoint)
    {
        // Instantiate the projectile at the fire point and get its Rigidbody
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Apply force to the projectile to shoot it forward
        rb.velocity = firePoint.forward * projectileSpeed;
    }
}
