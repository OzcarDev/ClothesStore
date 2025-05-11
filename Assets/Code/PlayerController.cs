using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Movement playerMovement;
    private Interactor playerInteractor;
    private Animator animator;
    private void Start()
    {
        playerMovement = GetComponent<Movement>();
        animator = GetComponentInChildren<Animator>();
        playerInteractor = GetComponentInChildren<Interactor>();
    }

    private void FixedUpdate()
    {
       playerMovement.Move(moveInput);
    }

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.IsPaused)
        {
            animator.SetBool("isWalking", true);



            if (context.canceled)
            {
                animator.SetBool("isWalking", false);
                animator.SetFloat("LastInputX", moveInput.x);
                animator.SetFloat("LastInputY", moveInput.y);
            }

            moveInput = context.ReadValue<Vector2>();

            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        }
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            if (!GameManager.Instance.IsPaused)
            {

                playerInteractor.Interact();
            }
        }
    }
}
