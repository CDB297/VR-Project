using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum AIState
    {
        Idle, Patrolliing, Chasing,
    }

    [Header("Patrol")]
    [SerializeField] private Transform wayPoints;
    [SerializeField] private float waitAtPoint = 2f;
    private int currentWaypoint;
    private float waitCounter;

    [Header("Components")]
    NavMeshAgent agent;

    [Header("AI States")]
    [SerializeField] private AIState currentState;

    [Header("Chasing")]
    [SerializeField] private float chaseRange;

    [Header("Suspicious")]
    [SerializeField] private float suspiciousTime;
    private float timeSinceLastSawPlayer;
    private GameObject player;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        waitCounter = waitAtPoint;
        timeSinceLastSawPlayer = suspiciousTime;
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        switch (currentState)
        {
            case AIState.Idle:
                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.Patrolliing;
                    agent.SetDestination(wayPoints.GetChild(currentWaypoint).position);
                }
                break;

            case AIState.Patrolliing:
                if (agent.remainingDistance <= 0.2f)
                {
                    int nextWaypoint = UnityEngine.Random.Range(0, wayPoints.childCount);
                    currentWaypoint = nextWaypoint;
                    currentState = AIState.Idle;
                    waitCounter = waitAtPoint;
                }
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.Chasing;
                }
                break;

            case AIState.Chasing:
                agent.SetDestination(player.transform.position);
                if (distanceToPlayer > chaseRange)
                {
                    timeSinceLastSawPlayer = Time.deltaTime;
                    currentState = AIState.Patrolliing;

                    if (timeSinceLastSawPlayer <= 0)
                    {
                        timeSinceLastSawPlayer = suspiciousTime;
                        agent.isStopped = false;
                        currentState = AIState.Patrolliing;
                    }
                }
                break;
        }
    }
}
