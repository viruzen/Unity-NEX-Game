using UnityEngine;
using UnityEngine.UI; // Include this to use UI components

public class Player : MonoBehaviour
{
    public int health = 100; // Player's health
    public int damageTaken = 10; // Damage taken per hit
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public Text hpText; // Reference to the health text UI element

    private void Start()
    {
        // Ensure Game Over panel is hidden at the start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Update the UI display at the start
        UpdateHealthDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(damageTaken); // Call method to take damage
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Reduce health
        Debug.Log("Player took damage! Health: " + health);
        UpdateHealthDisplay(); // Update health display

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
        // Optionally: Stop the player from moving or perform other game over actions
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
