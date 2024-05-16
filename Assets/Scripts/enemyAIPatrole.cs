using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAIPatrole : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;

    [SerializeField] private GameObject thisObject;

    [SerializeField] LayerMask groundLayer, playerLayer;

    public Progress progressCheck;

    private AudioSource manScreaming;
    private bool isFire;
    private bool isScreaming;

    //patrol
    Vector3 destPoint;
    bool walkpointSet;

    [SerializeField] float range;

    // Start is called before the first frame update
    void Start()
    {
        manScreaming = thisObject.GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("player");
        manScreaming.Stop();
        isScreaming = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        isFire = progressCheck.fireStarted();
        if(isFire && !isScreaming)
        {
            manScreaming.Play();
            isScreaming = true;
        }
    }

    void Patrol()
    {
        if (!walkpointSet)
        {
            SearchForDest();
        }
        if(walkpointSet) 
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
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if(Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
