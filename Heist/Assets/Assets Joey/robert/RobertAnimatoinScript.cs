using UnityEngine;
using UnityEngine.AI;

public class RobertAnimationScript : MonoBehaviour
{
    public Transform rplayer;
    private NavMeshAgent ragent;
    private Animator ranimator;
    public float rattackRange = 0.5f;
    public AiBehavior beh;

    private void Start()
    {
        ragent = GetComponent<NavMeshAgent>();
        ranimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, rplayer.position);

        if (distance <= rattackRange)
        {
            RStartAttack();
        }
        else
        {
            RStartWalking();
        }
        if (beh.chasing == true)
        { ragent.destination = rplayer.position; }
        else 
        { 
            beh.Wander();
        }
    }

    void RStartAttack()
    {
        ranimator.SetBool("isWalking", false);
        ranimator.SetTrigger("Attack");
        ragent.isStopped = false;
    }

    void RStartWalking()
    {
        ranimator.SetBool("isWalking", true);
        ragent.isStopped = false;
    }

    // Call this method at the end of the attack animation via Animation Event
    public void ROnAttackAnimationEnd()
    {
        ragent.isStopped = false;
    }
}
