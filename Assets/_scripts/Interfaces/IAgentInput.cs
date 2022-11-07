using UnityEngine;
using UnityEngine.Events;

public interface IAgentInput
{
    UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    UnityEvent<Vector2> OnPointerPostionChange { get; set; }
}