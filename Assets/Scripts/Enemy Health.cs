using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 50;
    private int currentHealth;

    [Header("Damage Feedback")]
    public Renderer enemyRenderer;          // Renderer for visual feedback (optional)
    public Color damageColor = Color.red;   // Color to flash when taking damage
    public float colorFlashDuration = 0.1f; // Duration of color flash
    private Color originalColor;            // Original color to revert back to

    public delegate void EnemyDeathEvent();
    public event EnemyDeathEvent OnEnemyDeath; // Event to notify other systems

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Enemy Health Initialized to: " + currentHealth);

        // Store original color if Renderer is assigned
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy took damage. Current Health: " + currentHealth);

        // Optional: Trigger color flash to show damage
        if (enemyRenderer != null)
        {
            StartCoroutine(FlashDamageColor());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died!");

        OnEnemyDeath?.Invoke();  // Trigger event for other systems to respond

        Destroy(gameObject);      // Destroy enemy on death
    }

    private System.Collections.IEnumerator FlashDamageColor()
    {
        // Change color to indicate damage
        enemyRenderer.material.color = damageColor;
        yield return new WaitForSeconds(colorFlashDuration);
        // Revert back to original color
        enemyRenderer.material.color = originalColor;
    }
}
