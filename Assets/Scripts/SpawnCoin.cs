using UnityEngine;

public class Coin : MonoBehaviour
{
    public float spawnRange = 10f;
    public float spawnHeight = 0f;

    private void Start()
    {
        Respawn(); // Call respawn on start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure this checks the player correctly
        {
            // Collect the coin and respawn it
            Respawn();

            // Check if GameManager instance is available before calling
            if (GameManager.Instance != null)
            {
                GameManager.Instance.IncrementScore(); // Increment the score
            }
            else
            {
                Debug.LogError("GameManager instance is null. Make sure GameManager is added to the scene.");
            }
        }
    }

    private void Respawn()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            spawnHeight,
            Random.Range(-spawnRange, spawnRange)
        );

        transform.position = randomPosition; // Move coin to a random position
    }
}
