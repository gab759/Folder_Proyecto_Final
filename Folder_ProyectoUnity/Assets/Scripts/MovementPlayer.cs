using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [Header("Lane References")]
    public Transform[] laneTransforms;

    public float moveSpeed = 5.0f;

    private int currentLane = 1;
    private float targetX;

    void Start()
    {
        if (laneTransforms.Length != 3)
        {
            Debug.LogError("El arreglo laneTransforms debe contener exactamente 3 elementos.");
            return;
        }

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
        if (context.performed && currentLane < laneTransforms.Length - 1)
        {
            currentLane++;
            UpdateTargetPosition();
        }
    }

    private void UpdateTargetPosition()
    {
        targetX = laneTransforms[currentLane].position.x;
    }
}