using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobertAnimatie : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public float attackRange = 2f;
    public float komdanr = 60f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        agent.destination = player.position;


        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {

            Attack();
        }
        if (Vector3.Distance(transform.position, player.position) <= komdanr)
        {

            komdanrobert();
        }

    }

    void Attack()
    {

        animator.SetTrigger("Attack");
    }

    void komdanrobert()
    {
        animator.SetTrigger("komdanr");
    }
}