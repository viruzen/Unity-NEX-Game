using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent nav;

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
        }
    }
}
