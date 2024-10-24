using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;  // How long before the projectile is destroyed

    void Start()
    {
        Destroy(gameObject, lifetime);  // Destroy the projectile after its lifetime expires
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision with target
        if (collision.gameObject.tag == "Enemy") // Assuming the target has the "Enemy" tag
        {
            // Do something like deal damage
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
