using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the obstacle!");
            
        }
    }
}
