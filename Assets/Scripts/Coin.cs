using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coin : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float range = 10;
    private Player player;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        navAgent.isStopped = false;
        navAgent.speed = 3;
    }

    void Update()
    {
        GoRandom();
        GoAway();
    }

    void GoRandom()
    {
        Vector3 point;
        if (!navAgent.hasPath && RandomPoint(transform.position, range, out point))
        {
            navAgent.SetDestination(point);
            Debug.DrawRay(point, Vector3.up, Color.blue, 5.0f);
        }
    }

    void GoAway()
    {
        Vector3 directionPlayerToCoin = transform.position - player.transform.position;
        Vector3 runTo = transform.position + directionPlayerToCoin;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < range) navAgent.SetDestination(runTo);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
