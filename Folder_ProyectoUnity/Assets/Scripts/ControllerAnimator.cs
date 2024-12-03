using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ControllerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float obstacleForceZ = 1f;
    [Header("Boleanos: ")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool puedoSaltar=true;
    [SerializeField] private bool canSlide=true;
    [Header("Collider Settings")]
    [SerializeField] private BoxCollider characterCollider;
    private Vector3 originalColliderCenter;
    private Vector3 originalColliderSize;
    void Awake()
    {
        animator = GetComponent<Animator>();
        puedoSaltar = true;

        originalColliderCenter = characterCollider.center;
        originalColliderSize = characterCollider.size;
    }

    void FixedUpdate()
    {
        DetectarSuelo();
    }
    

    public void OnJump(InputAction.CallbackContext context)
    {
        if (puedoSaltar && context.performed && isGrounded)
        {
            animator.SetBool("salte", true);
            animator.SetBool("tocoSuelo", false);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("sALTE?");
            
        }
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && canSlide && !animator.GetBool("BoolSlide"))
        {
            animator.SetBool("BoolSlide", true);
            characterCollider.center = new Vector3(-0.03434503f, 0.3755717f, 0.5863609f);
            characterCollider.size = new Vector3(0.6290735f, 0.7711431f, 1.467098f);
            StartCoroutine(ResetSlide());
        }
        else if (!isGrounded)
        {
            animator.SetBool("BoolSlide", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            rb.AddForce(new Vector3(0, 0, -obstacleForceZ), ForceMode.Impulse);
            Debug.Log("Me empujaron?");
        }
        if (other.CompareTag("Obstacle") && !puedoSaltar)
        {
            rb.AddForce(new Vector3(0, 0, -2), ForceMode.Impulse);
            Debug.Log("Me empujaron saltando?");
        }
        if (other.CompareTag("Loss"))   
        {
            GameManager.Instance.TriggerLose();
        }
    }
    private IEnumerator ResetSlide()
    {
        yield return new WaitForSeconds(1.0f);
        characterCollider.center = originalColliderCenter;
        characterCollider.size = originalColliderSize;
        animator.SetBool("BoolSlide", false);
    }

    private void DetectarSuelo()
    {
        Vector3 rayOrigin = transform.position + Vector3.down * 0.001f;
        isGrounded = Physics.Raycast(rayOrigin, Vector3.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(rayOrigin, Vector3.down * groundCheckDistance, Color.red);

        animator.SetBool("tocoSuelo", isGrounded);

        if (isGrounded)
        {
            canSlide = true;
            animator.SetBool("salte", false);
            puedoSaltar = true;
        }
        else if(!isGrounded)
        {
            canSlide = false;
            puedoSaltar = false;
            animator.SetBool("tocoSuelo", false);
            
        }
    }
}