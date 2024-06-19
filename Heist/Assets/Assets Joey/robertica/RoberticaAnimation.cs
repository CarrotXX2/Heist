using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoberticaAnimatie : MonoBehaviour
{
    public Transform rplayer;
    private NavMeshAgent ragent;
    private Animator ranimator;
    public float rattackRange = 2f;

    private void Start()
    {
        ragent = GetComponent<NavMeshAgent>();
        ranimator = GetComponent<Animator>();
    }

    private void Update()
    {

        ragent.destination = rplayer.position;


        if (Vector3.Distance(transform.position, rplayer.position) <= rattackRange)
        {

            RAttack();
        }
    }

    void RAttack()
    {

        ranimator.SetTrigger("RAttack");
    }
}