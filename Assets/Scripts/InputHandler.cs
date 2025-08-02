using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private CannonHandler cannon;
    private bool isDragging = false;
    private float lastMouseX;
    private float moveDelta;
    public void Tick()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!isDragging && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z)))
        {
            StartDragging();
        }
        else if (isDragging && (Input.GetMouseButtonUp(0)|| Input.GetKeyUp(KeyCode.Z)))
        {
            StopDragging();
        }
        else if (isDragging && (Input.GetMouseButton(0)|| Input.GetKey(KeyCode.Z)))
        {
            Drag();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        lastMouseX = Input.mousePosition.x;
    }

    private void Drag()
    {
        float x = Input.mousePosition.x;
        Move(x - lastMouseX);
        lastMouseX = x;
    }

    private void StopDragging()
    {
        isDragging = false;
    }

    private void Move(float delta)
    {
        cannon.Move(delta);
    }
}
