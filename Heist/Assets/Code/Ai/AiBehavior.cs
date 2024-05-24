using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround, WhatIsPlayer;

    //patrol
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    // states
    public float sightRange, attackRange;
    public bool playerInSight, PlayerInAttackRange;
    // Start is called before the first frame update

     private void Awake()
    {
        player = GameObject.Find("Speler").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSight && !PlayerInAttackRange) patrol();
        if (playerInSight && !PlayerInAttackRange) chase();
        if (playerInSight && PlayerInAttackRange) attack();
    }
    public void patrol()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalk = transform.position - walkPoint;
        if (distanceToWalk.magnitude < 1f)
        {
          walkPointSet = false;
        }
    }
    public void SearchWalkPoint()
    {
        float randomz = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y + randomz);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;        
        }
    }
    public void chase()
    {
        agent.SetDestination(player.position);
    }
    public void attack()
    { 
      player.LookAt(transform.position);
      transform.LookAt(player);
      Rigidbody RB = player.GetComponent<Rigidbody>();
        RB.isKinematic = false;
       
    }
}
