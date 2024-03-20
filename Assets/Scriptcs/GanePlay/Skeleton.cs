using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform LeftPoint;
    [SerializeField] private Transform RightPoint;
    [SerializeField] private HitBox HitBoxCollider;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private GameObject SkeletonParticle;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 5f;

    private Vector3 LeftPointPosition;
    private Vector3 RightPointPosition;
    private bool IsMovingRight = true;


    private void Start()
    {
        LeftPointPosition = LeftPoint.position;
        RightPointPosition = RightPoint.position;

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

        #region chodzenie
        float MoveValue = movementSpeed * Time.deltaTime;
        if (IsMovingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightPointPosition, MoveValue);
            transform.rotation = Quaternion.Euler(0, 0, 0);

            if (transform.position == RightPointPosition)
            {
                IsMovingRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftPointPosition, MoveValue);
            transform.rotation = Quaternion.Euler(0, 180, 0);

            if (transform.position == LeftPointPosition)
            {
                IsMovingRight = true;
            }
        }

        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent(out Health health))
        //{
        //    health.Damage(1);
        //}
    }
}
