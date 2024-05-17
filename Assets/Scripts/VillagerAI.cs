using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer;

    // Patrol parameters
    Vector3 destPoint;
    bool walkpointSet;

    [SerializeField] Vector2 boundaryMin; // Minimum boundary for X and Z coordinates
    [SerializeField] Vector2 boundaryMax; // Maximum boundary for X and Z coordinates

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet)
        {
            SearchForDest();
        }
        if (walkpointSet)
        {
            agent.SetDestination(destPoint);
        }
        if (Vector3.Distance(transform.position, destPoint) < 10)
        {
            walkpointSet = false;
        }
    }

    void SearchForDest()
    {
        float x = Random.Range(boundaryMin.x, boundaryMax.x); // Random X within boundaries
        float z = Random.Range(boundaryMin.y, boundaryMax.y); // Random Z within boundaries

        destPoint = new Vector3(x, transform.position.y, z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
