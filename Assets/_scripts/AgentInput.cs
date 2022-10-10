using Newtonsoft.Json.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    private Camera mainCamera;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPostionChange { get; set; }

    [field: SerializeField]
    public UnityEvent<int> OnPointerAreaChange { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetPointerArea();
    }

    private void GetPointerInput()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = mainCamera.nearClipPlane;
        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousPos);
        OnPointerPostionChange?.Invoke(mouseInWorldSpace);
    }

    // 0 = most left
    // 1 = most up
    // 2 = most right
    // 3 = most down
    private void GetPointerArea()
    {
        var mousePostion = Input.mousePosition;
        mousePostion = mainCamera.ScreenToViewportPoint(mousePostion);
        // bottom left corner
        if(mousePostion.x < 0.5 && mousePostion.y < 0.5)
        {
            OnPointerAreaChange?.Invoke(mousePostion.x < mousePostion.y ? 0 : 3);
        }
        //Top left corner
        else if(mousePostion.x < 0.5 && mousePostion.y > 0.5)
        {
            var DisToTop = 1 - mousePostion.y;
            OnPointerAreaChange?.Invoke(mousePostion.x < DisToTop ? 0 : 1);
        }
        //Top right corner
        else if (mousePostion.x > 0.5 && mousePostion.y > 0.5)
        {
            var DisToTop = 1 - mousePostion.y;
            var DisToRight = 1 - mousePostion.x;
            OnPointerAreaChange?.Invoke(DisToRight > DisToTop ? 1 : 2);
        }
        // bottom right corner
        else if (mousePostion.x > 0.5 && mousePostion.y < 0.5)
        {
            var DisToRight = 1 - mousePostion.x;
            OnPointerAreaChange?.Invoke(DisToRight < mousePostion.y ? 2 : 3);
        }
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
