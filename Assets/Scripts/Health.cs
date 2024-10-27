using UnityEngine;
using UnityEngine.UI;  // If using UI elements like a health bar

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider;  // UI Slider to show health (optional)

    public delegate void PlayerDeathEvent();
    public event PlayerDeathEvent OnPlayerDeath;  // Event to notify when player dies

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health Initialized to: " + currentHealth);

        UpdateHealthUI();  // Update UI at start
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took damage. Current Health: " + currentHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Clamp to max health
        Debug.Log("Player healed. Current Health: " + currentHealth);

        UpdateHealthUI();
    }

    private void Die()
    {
        Debug.Log("Player has died!");

        OnPlayerDeath?.Invoke();  // Notify other systems of the player's death

        // Handle player death (e.g., restart game, respawn, etc.)
        Destroy(gameObject);  // Remove player object; modify if a respawn system is used
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }
}
