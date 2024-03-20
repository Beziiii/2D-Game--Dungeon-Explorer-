using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovemnet movement;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Transform graphicTransform;


    [Space(3)]
    [Header("Parameters")]
    [SerializeField] private string IsMovingParameter;
    [SerializeField] private string IsJumpingParameter;
    [SerializeField] private string IsCrouchingParameter;
    [SerializeField] private string IsFallingParameter;
    //s[SerializeField] private string IsAttackingParameter;

    private void Update()
    {
        UpdateAnimations();
        UpdateRotation();

    }

    private void UpdateRotation()
    {
        if (movement.GetCurrentInputX() > 0)
        {
            graphicTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (movement.GetCurrentInputX() < 0)
        {
            graphicTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

   

    private void UpdateAnimations()
    {
        animator.SetBool(IsMovingParameter, movement.IsMoving());

        if (playerRigidbody.velocity.y > 0.1f)
        {
            animator.SetBool(IsJumpingParameter, true);
            animator.SetBool(IsFallingParameter, false);
        }

        else if (playerRigidbody.velocity.y < -0.1f)
        {
            animator.SetBool(IsJumpingParameter, false);
            animator.SetBool(IsFallingParameter, true);
        }

        else
        {
            animator.SetBool(IsJumpingParameter, false);
            animator.SetBool(IsFallingParameter, false);
        }

        //if (playerRigidbody.velocity.y < -0.1f)
        //{
        //    animator.SetBool(IsCrouchingParameter, true);

        //} // psuje kucanie (l¹dujesz to coruch siê katywuje)

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.8310013f, 0.810526f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-4.162738f, -2.611531f);
            // spróbuj daæ offset
            animator.SetBool(IsCrouchingParameter, true);
            // animator.SetBool(IsFallingParameter, false); // nic nie daje 
            animator.SetBool(IsJumpingParameter, false);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.8310013f, 1.610526f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-4.162738f, -2.16301f);
            animator.SetBool(IsCrouchingParameter, false);

        }

        // rozwi¹¿ problem z bunny hopem

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }


    }
}

