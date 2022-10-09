using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;
    
    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }
    
    [SerializeField]
    protected float currentVelocity = 3;
    protected Vector2 MovementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movermentInput)
    {
        if (movermentInput.magnitude > 0)
        {
            MovementDirection = movermentInput.normalized;
        }
        currentVelocity = calculateSpeed(movermentInput);
    }

    private float calculateSpeed(Vector2 movermentInput)
    {
        if(movermentInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        rigidbody2d.velocity = MovementDirection.normalized * currentVelocity;
    }
}
