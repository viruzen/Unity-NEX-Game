using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent nav;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav.destination = playerTransform.position;
    }

}