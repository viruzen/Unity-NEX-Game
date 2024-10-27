using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;             // Bullet prefab reference
    public Transform bulletSpawnPoint;          // Point from where bullets spawn
    public float bulletSpeed = 50f;             // Speed of the bullet
    public float bulletLifetime = 3f;           // Lifetime of the bullet (seconds)

    [Header("Shooting Settings")]
    public float shootingCooldown = 0.5f;       // Time between shots
    private float lastShotTime;                 // Time of the last shot

    void Update()
    {
        // Check for shooting input and cooldown
        if (Input.GetMouseButtonDown(0) && Time.time > lastShotTime + shootingCooldown)
        {
            Shoot();
            lastShotTime = Time.time;           // Update last shot time
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate bullet and set its initial position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Assign velocity to the bullet if it has a Rigidbody
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }

            // Automatically destroy the bullet after a set lifetime
            Destroy(bullet, bulletLifetime);
        }
        else
        {
            Debug.LogError("Bullet prefab or spawn point is not assigned!");
        }
    }
}
