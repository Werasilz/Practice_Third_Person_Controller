using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    public bool isAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        Action();
        Attack();
    }

    void Action()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !playerController.isMoving && !isAttack)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetInteger("Action", 1);
                isAttack = true;
            }
        }
    }

    void Attack()
    {
        if (isAttack && !animator.GetBool("isRun"))
        {
            animator.SetBool("isAttack", true);
        }
    }
}
