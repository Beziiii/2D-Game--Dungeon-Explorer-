using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttack : MonoBehaviour
{

    public Animator animator;
    public float attackDelay;
    public Transform WeaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }


    }

    IEnumerator Attack()
    {
        animator.Play("Attack");

        Collider2D enemy = Physics2D.OverlapCircle(WeaponTransform.position, weaponRange, enemyLayer);


        yield return new WaitForSeconds(attackDelay);

        enemy.GetComponent<EnemyHealth>().TakeDamage(weaponDamage);

        


    }
}
