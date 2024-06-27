using UnityEngine;
using UnityEngine.AI;

public class RoberticaAnimationScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public float attackRange = 0.5f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            StartAttack();
        }
        else
        {
            StartWalking();
        }

        agent.destination = player.position;
    }

    void StartAttack()
    {
        animator.SetBool("isWalking", false);
        animator.SetTrigger("Attack");
        agent.isStopped = true;
    }

    void StartWalking()
    {
        animator.SetBool("isWalking", true);
        agent.isStopped = false;
    }

    // Call this method at the end of the attack animation via Animation Event
    public void OnAttackAnimationEnd()
    {
        agent.isStopped = false;
    }
}
