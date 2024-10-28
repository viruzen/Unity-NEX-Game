using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint; // Point from where bullets will be instantiated
    public float shootingInterval = 2f; // Time between shots
    public float shootingRange = 10f; // Range within which the enemy can shoot
    private Transform playerTransform;
    private NavMeshAgent nav;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        nav = GetComponent<NavMeshAgent>();

        if (nav == null)
        {
            Debug.LogError("NavMeshAgent component missing from " + gameObject.name);
        }

        // Start shooting at random intervals
        InvokeRepeating("ShootAtPlayer", shootingInterval, shootingInterval);
    }

    private void Update()
    {
        // Check if NavMeshAgent and playerTransform are assigned
        if (nav != null && playerTransform != null)
        {
            nav.destination = playerTransform.position; // Move towards player
        }
    }

    private void ShootAtPlayer()
    {
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= shootingRange)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Instantiate bullet
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = (playerTransform.position - firePoint.position).normalized * 30f; // Shoot towards player
            }
        }
    }
}
