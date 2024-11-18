using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public float laneDistance = 1.0f;
    public float moveSpeed = 5.0f;

    private int currentLane = 1;
    private Vector3 targetPosition;
    private void Start()
    {
        UpdateTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed && currentLane > 0)
        {
            currentLane--;
            UpdateTargetPosition();
        }
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.performed && currentLane < 2)
        {
            currentLane++;
            UpdateTargetPosition();
        }
    }

    private void UpdateTargetPosition()
    {
        float xPosition = (currentLane - 1) * laneDistance;
        targetPosition = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}