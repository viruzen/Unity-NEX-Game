using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damageAmount = 10;             // Damage dealt to the player
    public float attackCooldown = 1.5f;       // Cooldown between attacks

    private float lastAttackTime = 0f;        // Tracks time of last attack

    private void OnTriggerStay(Collider other)
    {
        // Check if the collision is with the player
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Attack if the cooldown period has passed and player has a health component
            if (playerHealth != null && Time.time > lastAttackTime + attackCooldown)
            {
                playerHealth.TakeDamage(damageAmount);  // Apply damage
                lastAttackTime = Time.time;             // Reset the attack cooldown
            }
        }
    }
}
