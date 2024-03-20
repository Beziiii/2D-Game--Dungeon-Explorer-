using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float StarTtimeBtwAttack;
    public Animator animator;
    public Transform attackPos;
    public LayerMask EnemyLayer;
    public float attackRange;
    public int damage;

    private void Update()
    {
        //    Vector3 currentScale = gameObject.transform.localScale;
        //    currentScale.x *= -1;
        //    if (timeBtwAttack <= 0)
        //    {
        //        if (Input.GetKey(KeyCode.Mouse0))
        //        {
        //           // animator.SetTrigger("IsAttacking");
        //            Collider2D[] enemiesToDamagae = Physics2D.OverlapCircleAll(attackPos.position, attackRange, EnemyLayer);

        //            for (int i = 0; i < enemiesToDamagae.Length; i++)
        //            {
        //               // enemiesToDamagae[i].GetComponent<EnemyHealth>().TakeDamage(damage);

        //            }




        //        }
        //        timeBtwAttack = StarTtimeBtwAttack;
        //    }
        //    else
        //    {
        //        timeBtwAttack -= Time.deltaTime;
        //    }
        //}
        //private void OnDrawGizmosSelected()
        //{
        //    Gizmos.DrawWireSphere(attackPos.position, attackRange);
        //}

    }
}
