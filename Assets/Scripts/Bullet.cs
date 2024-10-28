using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Damage done by the bullet

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if we hit the player
        {
            Player player = other.GetComponent<Player>(); // Get the Player component
            if (player != null)
            {
                player.TakeDamage(damage); // Call damage method
            }
            Destroy(gameObject); // Destroy the bullet
        }
    }

    private void OnBecameInvisible() // Optional: Destroy bullet if it goes off-screen
    {
        Destroy(gameObject);
    }
}
