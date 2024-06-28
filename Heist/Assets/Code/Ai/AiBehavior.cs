using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class AiBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float chaseDistance = 1f; // Distance at which the neighbor will start chasing the player
    public float wanderRadius = 5f; // Radius for random wandering
    public float sitChance = 0.1f; // Chance to sit down when entering a couch area
    public float walkToCouchChance = 0.2f; // Chance to walk to the couch during wandering
    public float attackRange = 0.5f;
    public Transform playerCamera;
    public MoveMent movement;

    private NavMeshAgent agent;
    private Vector3 wanderTarget;
    private bool isSitting = false;
    private bool isNearCouch = false;
    private List<Transform> couches = new List<Transform>(); // List of couches
    public GameObject robertHead;
    public AudioClip jumpScare;
    public AudioClip hey;
    public AudioClip DontMess;
    public bool chasing;
    public bool jumped = false;
    public FadeInImage deathScreen;
    public ItemInBus money;
    private float chaseCooldown = 3f; // Cooldown period before re-evaluating chase state
    private float lastChaseTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderTarget = transform.position;
        chasing = false;
        

        // Find all couches in the scene
        foreach (GameObject couch in GameObject.FindGameObjectsWithTag("Couch"))
        {
            couches.Add(couch.transform);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance && Time.time > lastChaseTime + chaseCooldown)
        {
            ChasePlayer();
        }
        else if (!chasing)
        {
            Wander();

            if (distanceToPlayer <= attackRange)
            {
                playerCamera.LookAt(robertHead.transform.position);
                agent.speed = 0f;
                if (!jumped)
                {
                    jumped = true;
                    AudioSource.PlayClipAtPoint(DontMess, robertHead.transform.position);
                    AudioSource.PlayClipAtPoint(jumpScare, robertHead.transform.position);
                    deathScreen.Death();
                    movement.death();

                    if (money.money >= 500f)
                    {
                        money.money -= 500f;
                    }
                }
            }

            if (isSitting)
            {
                // Even when sitting, check if the player is within chase distance
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
                if (distanceToPlayer <= chaseDistance)
                {
                    ChasePlayer();
                }
                else
                {
                    if (chasing)
                    {
                        chasing = false;
                        agent.ResetPath(); // Clear the current path
                        Wander();
                    }

                    if (!agent.hasPath || agent.remainingDistance < 0.5f)
                    {
                        Wander();

                        // Randomly decide to sit down if near a couch
                        if (isNearCouch && Random.value < sitChance * Time.deltaTime)
                        {
                            StartCoroutine(SitDown());
                        }
                    }
                }
            }
        }

        UpdateRotation();
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if (!chasing)
        {
            AudioSource.PlayClipAtPoint(hey, robertHead.transform.position);
            chasing = true;
            lastChaseTime = Time.time; // Reset the chase cooldown
        }
    }

    void Wander()
    {
        if (!agent.hasPath || agent.remainingDistance < 0.5f)
        {
            if (Random.value < walkToCouchChance && couches.Count > 0)
            {
                // Choose a random couch to walk to
                Transform couch = couches[Random.Range(0, couches.Count)];
                StartCoroutine(WalkToCouchAndSit(couch));
            }
            else
            {
                wanderTarget = GetRandomPoint(transform.position, wanderRadius);
                agent.SetDestination(wanderTarget);
            }
        }
    }

    IEnumerator WalkToCouchAndSit(Transform couch)
    {
        agent.SetDestination(couch.position);

        while (agent.pathPending || agent.remainingDistance > 0.5f)
        {
            yield return null;
        }

        // Call the SitDown coroutine when reaching the couch
        StartCoroutine(SitDown());
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
        float sitTime = Random.Range(7, 15); // Sit down for a random period between 7 and 15 seconds
        yield return new WaitForSeconds(sitTime);

        isSitting = false;
        agent.isStopped = false; // Resume movement
        walkToCouchChance = 0.1f;
    }
}