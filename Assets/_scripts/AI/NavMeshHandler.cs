using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshHandler : MonoBehaviour
{
    public NavMeshAgent agent;
    public MovementDataSO movementData;

    public UnityEvent<bool> onMove;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = movementData.maxSpeed;
        agent.acceleration = movementData.acceleration;
    }

    public void MoveToTarget(Transform target)
    {
        agent.SetDestination(target.position);
        onMove?.Invoke(true);
    }

    public void ClearTarget()
    {
        agent.ResetPath();
        onMove?.Invoke(false);
    }
}
