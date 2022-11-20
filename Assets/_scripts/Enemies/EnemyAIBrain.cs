using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput
{
    [field: SerializeField]
    public GameObject Target { get; set; }

    [field: SerializeField]
    public AIState CurrentState { get; private set; }


    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }
    [field: SerializeField]
    public UnityEvent OnfireButtonReleased { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPostionChange { get; set; }

    public NavMeshHandler NavHandler;

    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject;
        NavHandler = GetComponent<NavMeshHandler>();
    }

    private void Update()
    {
        if(Target == null)
        {
            OnMovementKeyPressed?.Invoke(Vector2.zero);

        }
        else
        {
            CurrentState.UpdateState();
        }
    }

    public void Attack()
    {
        OnFireButtonPressed?.Invoke();
    }
    public void Move(Vector2 movementDirection, Vector2 targetPosition)
    {
        OnMovementKeyPressed?.Invoke(movementDirection);
        OnPointerPostionChange?.Invoke(targetPosition);
    }

    internal void ChangeToState(AIState State)
    {
        CurrentState = State;
    }
}
