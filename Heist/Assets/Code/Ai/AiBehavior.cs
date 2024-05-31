using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float chaseDistance = 10f; // Distance at which the neighbor will start chasing the player
    public float wanderRadius = 5f; // Radius for random wandering
    public float sitChance = 1f; // Chance to sit down when entering a couch area
    public float walkToCouchChance = 0.1f; // Chance to walk to the couch during wandering

    private NavMeshAgent agent;
    private Vector3 wanderTarget;
    private bool isSitting = false;
    private bool isNearCouch = false;
    private List<Transform> couches = new List<Transform>(); // List of couches

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderTarget = transform.position;

        // Find all couches in the scene
        foreach (GameObject couch in GameObject.FindGameObjectsWithTag("Couch"))
        {
            couches.Add(couch.transform);
        }
    }

    void Update()
    {
        if (isSitting)
        {
            // Even when sitting, check if the player is within chase distance
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance)
            {
                StopAllCoroutines(); // Stop any sitting-related coroutines
                isSitting = false; // Get up from sitting
                agent.isStopped = false;
                ChasePlayer();
            }
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance)
            {
                ChasePlayer();
            }
            else
            {
                Wander();
            }

            // Randomly decide to sit down if near a couch
            if (isNearCouch && Random.value < sitChance * Time.deltaTime)
            {
                StartCoroutine(SitDown());
            }
        }

        UpdateRotation();
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void Wander()
    {
        if (!agent.hasPath || agent.remainingDistance < 0.5f)
        {
            if (Random.value < walkToCouchChance && couches.Count > 0)
            {
                // Choose a random couch to walk to
                Transform couch = couches[Random.Range(0, couches.Count)];
                agent.SetDestination(couch.position);
                SitDown();
                // Stop walking for a random period before sitting down
            }
            else
            {
                wanderTarget = GetRandomPoint(transform.position, wanderRadius);
                agent.SetDestination(wanderTarget);
            }
        }
    }

    IEnumerator StopWalkingForRandomPeriod()
    {
        // Stop walking for a random period
        agent.isStopped = true;
        yield return new WaitForSeconds(Random.Range(10, 20));
        agent.isStopped = false;
    }

    Vector3 GetRandomPoint(Vector3 center, float radius)
    {
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += center;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPos, out hit, radius, 1);
        return hit.position;
    }

    void UpdateRotation()
    {
        if (agent.hasPath && agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            Vector3 direction = agent.velocity.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Couch"))
        {
            isNearCouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Couch"))
        {
            isNearCouch = false;
        }
    }

    IEnumerator SitDown()
    {
        isSitting = true;
        agent.isStopped = true; // Stop moving
        StartCoroutine(StopWalkingForRandomPeriod());

        // Sit down animation or behavior can be added here

        yield return new WaitForSeconds(Random.Range(7, 15)); // Sit down for a random period

        if (!isSitting)
        {
            yield break; // If sitting was interrupted by chasing, exit
        }
            
        isSitting = false;
        agent.isStopped = false; // Resume movement
    }
}