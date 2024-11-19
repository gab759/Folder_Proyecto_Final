using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public float laneDistance = 1.0f;
    public float moveSpeed = 5.0f;

    private int currentLane = 1;
    private float targetX;

    void Start()
    {
        UpdateTargetPosition();
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(
            Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime),
            transform.position.y,
            transform.position.z
        );

        transform.position = newPosition;
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
        targetX = (currentLane - 1) * laneDistance;
    }
}