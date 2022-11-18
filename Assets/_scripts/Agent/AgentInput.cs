using Newtonsoft.Json.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    private Camera mainCamera;
    private bool fireButtonDown = false;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPostionChangeView { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPostionChange { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    //opdatere vores GetMovementInput, GetPointerInput og GetFireInput
    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    // metode som viser hvordan vi skyder
    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButtonDown == false)
            {
                fireButtonDown = true;
                OnFireButtonPressed?.Invoke();
            }          
        } 
        else
        {
            if (fireButtonDown)
            {
                fireButtonDown = false;
                OnFireButtonReleased?.Invoke();
            }         
        }
    }

    // pointer position for vores mus, så den følger med vore main kamera
    private void GetPointerInput()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mainCamera.nearClipPlane;
        var mouseInView = mainCamera.ScreenToViewportPoint(mousPos);
        var mouseInWorld = mainCamera.ScreenToWorldPoint(mousPos);
        OnPointerPostionChangeView?.Invoke(mouseInView);
        OnPointerPostionChange?.Invoke(mouseInWorld);
    }

    //dette er vores movement for vore player, de kan bevæge sig Horizontal eller Vertical
    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
