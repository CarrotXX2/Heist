using UnityEngine;
using UnityEngine.AI;

public class AIAnimationController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public float animRange = 1f;
    public float attackRange = 1f;

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
        else if (distance <= animRange)
        {
            StartAnimation();
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
        animator.SetBool("isAnimating", false);
        animator.SetTrigger("Attack");
        
    }

    void StartAnimation()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isAnimating", true);
        agent.isStopped = true;
    }

    void StartWalking()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isAnimating", false);
        agent.isStopped = false;
    }

    // Call this method at the end of the attack animation via Animation Event
    public void OnAttackAnimationEnd()
    {
        agent.isStopped = false;
    }

    // Call this method at the end of the other animation via Animation Event
    public void OnAnimationEnd()
    {
        agent.isStopped = false;
    }
}
