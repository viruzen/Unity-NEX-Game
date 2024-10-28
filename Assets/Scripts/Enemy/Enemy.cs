using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform; // Reference to the player
    private NavMeshAgent nav;          // Reference to the NavMeshAgent
    public float attackRange = 1.5f;   // Distance within which the enemy can attack
    public int damageToPlayer = 10;    // Damage inflicted on the player
    private float attackCooldown = 1f; // Time between attacks
    private float lastAttackTime;       // Timer to manage attack cooldown

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        nav = GetComponent<NavMeshAgent>();

        if (nav == null)
        {
            Debug.LogError("NavMeshAgent component missing from " + gameObject.name);
        }
    }

    void Update()
    {
        // Check if NavMeshAgent and playerTransform are assigned
        if (nav != null && playerTransform != null)
        {
            nav.destination = playerTransform.position;

            // Check the distance to the player
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                // Call the method to damage the player
                DamagePlayer();
                lastAttackTime = Time.time; // Reset the last attack time
            }
        }
    }

    private void DamagePlayer()
    {
        Player playerScript = playerTransform.GetComponent<Player>(); // Get the Player component
        if (playerScript != null)
        {
            playerScript.TakeDamage(damageToPlayer); // Call the TakeDamage method on the player
            Debug.Log("Enemy attacked the player! Damage: " + damageToPlayer);
        }
    }
}
