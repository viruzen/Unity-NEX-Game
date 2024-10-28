using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Damage done by the bullet

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // to hit the player
        {
            Player player = other.GetComponent<Player>(); // Get Player component
            if (player != null)
            {
                player.TakeDamage(damage); // Call damage method
            }
            Destroy(gameObject); // Destroy the bullet
        }

        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Apply damage to enemy
                Destroy(gameObject); // Destroy bullet after it hits
            }
        }
    }

    private void OnBecameInvisible() // Optional: Destroy bullet if it goes off-screen
    {
        Destroy(gameObject);
    }
}
