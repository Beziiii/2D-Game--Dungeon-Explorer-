using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    [Header("References")]


    [SerializeField] private HitBox HitBoxCollider;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private GameObject SkeletonParticle;

    [Header("Shooting")]
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private GameObject FireBall;
    [SerializeField] private AudioClip FireWoosh;
    [SerializeField] private float ShootDelay = 1f;

    [Header("Animations")]
    [SerializeField] private Animator animator;
    [SerializeField] private string shootTrigger;

    private float shootTimer = 0f;



    private void Start()
    {


        HitBoxCollider.OnPlayerJump += TakeHit;
    }

    private void TakeHit()
    {
        AudioSource.PlayClipAtPoint(HitSound, transform.position);

        Destroy(gameObject);
        Instantiate(SkeletonParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= ShootDelay)
        {
            shootTimer -= ShootDelay;
            Shoot();
        }

    }

    private void Shoot()
    {
        var spawnedFireBall = Instantiate(FireBall, ShootPoint.position, Quaternion.identity);
        spawnedFireBall.transform.right = -transform.right;


        animator.SetTrigger(shootTrigger);
        AudioSource.PlayClipAtPoint(FireWoosh, transform.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent(out Health health))
        //{
        //    health.Damage(1);
        //}
    }
}
