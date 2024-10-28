using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // Maximum health for the enemy
    private int currentHealth;

    private void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce health by the damage amount
        Debug.Log("Enemy took damage! Current health: " + currentHealth);

        // Check if the enemy's health has reached zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died!");
        // Optionally play a death animation or particle effect here
        Destroy(gameObject); // Destroy the enemy game object
    }
}
