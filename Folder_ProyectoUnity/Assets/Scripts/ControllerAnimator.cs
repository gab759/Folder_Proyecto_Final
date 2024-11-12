using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAnimator : MonoBehaviour
{
    private Animator animator;
    public float jumpForce = 5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            animator.SetTrigger("Jumping");
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
}