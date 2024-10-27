using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float maxSpeed = 5f;                // Player movement speed
    public GameObject bulletPrefab;            // Reference to the bullet prefab
    public Transform bulletSpawnPoint;         // Position where bullets spawn
    public float bulletSpeed = 50f;            // Speed of the bullet
    public float shootingCooldown = 0.2f;      // Time between shots

    private float lastShotTime;                // Track the time of the last shot
    private Rigidbody rb;                      // Rigidbody component
    private Vector3 movementInput;             // Movement input vector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Prevent unwanted rotation from physics
    }

    void Update()
    {
        // Player movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movementInput = new Vector3(moveX, 0, moveZ).normalized * maxSpeed;

        // Player facing direction
        if (movementInput != Vector3.zero)
        {
            transform.forward = movementInput; // Set the forward direction
        }

        // Shooting logic - detect left mouse button click
        if (Input.GetMouseButtonDown(0) && Time.time > lastShotTime + shootingCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movementInput * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        // Instantiate the bullet at the spawn point and get its Rigidbody
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Check if the bullet has a Rigidbody component and shoot it forward
        if (bulletRb != null)
        {
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        // Destroy the bullet after a few seconds to avoid clutter
        Destroy(bullet, 3f);
    }
}
