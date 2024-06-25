using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoberticaAnimatie : MonoBehaviour
{
    public Transform rplayer;
    private NavMeshAgent ragent;
    private Animator ranimator;
    public float rattackRange = 4f;
    public float komdanRange = 7f;

    private bool isAttacking = false;
    private bool isInKomdanRange = false;

    private void Start()
    {
        ragent = GetComponent<NavMeshAgent>();
        ranimator = GetComponent<Animator>();
    }

    private void Update()
    {
        ragent.destination = rplayer.position;

        float distance = Vector3.Distance(transform.position, rplayer.position);

        if (distance <= rattackRange && !isAttacking)
        {
            RAttack();
        }
        else if (distance <= komdanRange && !isInKomdanRange)
        {
            KomdanRange();
        }
    }

    void RAttack()
    {
        isAttacking = true;
        isInKomdanRange = false;
        ragent.isStopped = true;
        ranimator.SetTrigger("RAttack");
    }

    void KomdanRange()
    {
        isInKomdanRange = true;
        isAttacking = false;
        ranimator.SetTrigger("komdanRange");
    }

    public void ResetAttackState()
    {
        isAttacking = false;
        isInKomdanRange = false;
        ragent.isStopped = false;
    }

}