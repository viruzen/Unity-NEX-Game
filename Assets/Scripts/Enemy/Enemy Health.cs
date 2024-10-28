using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100; // Starting health of the enemy

    public void TakeDamage(int damage)
    {
        health -= damage; // Subtract damage from health
        Debug.Log("Enemy took damage! Health: " + health);

        if (health <= 0)
        {
            Die(); // Call Die method if health is zero or less
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}