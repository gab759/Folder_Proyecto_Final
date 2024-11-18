using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float jumpForce = 8f;
    public bool puedoSaltar;
    [SerializeField] Rigidbody rb;
    void Awake()
    {
        puedoSaltar = false;
        animator = GetComponent<Animator>();
    }
    public void OnJump1(InputAction.CallbackContext context)
    {
        if (puedoSaltar && context.performed)
        {
            animator.SetBool("salte", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Salta hacia arriba
            puedoSaltar = false; // Deshabilitar el salto hasta que toque el suelo de nuevo
        }
        else if (!puedoSaltar && context.performed)
        {
            EstoyCayendo(); // Si intenta saltar mientras está en el aire
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
    public void EstoyCayendo()
    {
        animator.SetBool("tocoSuelo", true);
        animator.SetBool("salte", false);
    }
}
