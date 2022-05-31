using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    //public float enemyAIRadius = 5f;
    bool isProvoked = false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            Debug.Log("Fucking Stop");
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void AttackTarget()
    {
        Debug.Log("Shoot Target");
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.25f);
        //Gizmos.DrawSphere(transform.position, enemyAIRadius);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
