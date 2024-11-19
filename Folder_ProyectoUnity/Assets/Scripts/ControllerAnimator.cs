using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody rb;

    private bool puedoSaltar;

    void Awake()
    {
        animator = GetComponent<Animator>();
        puedoSaltar = false;
    }

    void Update()
    {
        DetectarSuelo();
    }

    public void OnJump1(InputAction.CallbackContext context)
    {
        if (puedoSaltar && context.performed)
        {
            animator.SetBool("salte", true);
            animator.SetBool("tocoSuelo", false);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("sALTE?");
            puedoSaltar = false;
        }
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("BoolSlide", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("BoolSlide", false);
        }
    }

    private void DetectarSuelo()
    {
        Vector3 rayOrigin = transform.position + Vector3.down * 0.1f;
        bool isGrounded = Physics.Raycast(rayOrigin, Vector3.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(rayOrigin, Vector3.down * groundCheckDistance, Color.red);

        animator.SetBool("tocoSuelo", isGrounded);

        if (isGrounded)
        {
            puedoSaltar = true;
            animator.SetBool("salte", false);
        }
        else
        {
            animator.SetBool("tocoSuelo", false);
        }
    }
}