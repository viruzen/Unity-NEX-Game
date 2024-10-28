using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100; // Player's health
    public int damageTaken = 10; // Damage taken per hit
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public Text hpText; // Reference to the health text UI element

    private void Start()
    {
        // Ensure the Game Over panel is hidden at the start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Update health display at the start
        UpdateHealthDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for collisions with enemies
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(damageTaken); // Call method to take damage from enemy
        }
        // Check for collisions with obstacles
        else if (other.CompareTag("Obstacle"))
        {
            TakeDamage(damageTaken); // Call method to take damage from obstacle
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Reduce health
        Debug.Log("Player took damage! Health: " + health);
        UpdateHealthDisplay(); // Update health display after taking damage

        if (health <= 0)
        {
            Die(); // Call die method if health is zero or less
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the Game Over panel
        }
        // Optionally, you may want to stop player movement or other actions here
        Destroy(gameObject); // Destroy the player object for now
    }

    private void UpdateHealthDisplay()
    {
        if (hpText != null)
        {
            hpText.text = "Player HP: " + health; // Update the health text UI
        }
    }
}
