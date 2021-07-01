using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private PlayerActions playerActions;

    public float movementSpeed;
    public float rotationSpeed;

    private float Horizontal => Input.GetAxis("Horizontal");
    private float Vertical => Input.GetAxis("Vertical");

    private Vector3 MoveDirection => Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(Horizontal, 0, Vertical);
    private Vector3 RotationDirection => Vector3.RotateTowards(transform.forward, MoveDirection, rotationSpeed * Time.deltaTime, 0);

    public bool isMoving => MoveDirection != Vector3.zero;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerActions = GetComponent<PlayerActions>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (!playerActions.isAttack && !animator.GetBool("isAttack"))
        {
            animator.SetBool("isRun", isMoving);
            rb.MovePosition(transform.position + MoveDirection * movementSpeed * Time.deltaTime);
            rb.MoveRotation(Quaternion.LookRotation(RotationDirection));
        }
    }
}
