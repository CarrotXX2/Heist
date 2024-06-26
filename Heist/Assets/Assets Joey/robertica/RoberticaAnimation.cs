using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimationController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public float animRange = 5f;
    public float attackRange = 0.5f;

    private bool isAttacking = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && !isAttacking)
        {
            StartAttack();
        }
        else if (distance <= animRange && !isAttacking)
        {
            StartAnimation();
        }
        else if (distance > animRange)
        {
            ResetStates();
        }

        // Update the agent's destination
        agent.destination = player.position;

        // Ensure the walking animation is playing if not attacking or in other animation
        if (!isAttacking && distance > animRange)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        agent.isStopped = true;
        animator.SetTrigger("Attack");
    }

    void StartAnimation()
    {
        isAttacking = false;
        agent.isStopped = true;
        animator.SetTrigger("Animation");
    }

    void ResetStates()
    {
        isAttacking = false;
        agent.isStopped = false;
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Animation");
    }

    // Call this method at the end of the attack animation via Animation Event
    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
        agent.isStopped = false;
        animator.ResetTrigger("Attack");
        animator.SetBool("isWalking", true);
    }

    // Call this method at the end of the other animation via Animation Event
    public void OnAnimationEnd()
    {
        isAttacking = false;
        agent.isStopped = false;
        animator.ResetTrigger("Animation");
        animator.SetBool("isWalking", true);
    }
}
