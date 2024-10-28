using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Set damage amount
    public float lifetime = 3f; // Lifetime of the bullet in seconds

    private void Start()
    {
        // Destroy the bullet after a certain lifetime to prevent clutter
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Check if we hit an enemy
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>(); // Get the Enemy component
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Call damage method
            }
        }

        // Destroy the bullet after it hits something
        Destroy(gameObject);
    }

    private void OnBecameInvisible() // Optional: Destroy bullet if it goes off-screen
    {
        Destroy(gameObject);
    }
}
