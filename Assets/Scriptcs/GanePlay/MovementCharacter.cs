using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovemnet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GroundDetector groundDetector;
    [SerializeField] private Transform Legs;
    [SerializeField] private GameObject langdingParticles;
    [SerializeField] private GameObject movementParticle;
    [SerializeField] private float langdingParticlesLifeTime = 1f;
    [SerializeField] private float movementParcileLifeTime = 0.3f;




    [Space(5)]
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float jumpPower = 2f;
    [SerializeField] private float DoublejumpPower = 5f;

    [Space(5)]
    [Header("Sounds")]
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private float MoveSoundDelay = 0.1f;
    [SerializeField] private AudioClip MoveSound;

    private float MoveSoundTimer = 0f;
    private float inputX;
    private bool isJumpingInput = false;
    private bool isDoubleJump = false;
    private Platform currentPlatform;





    private void Start()
    {
        groundDetector.OnLanding += HandleLanding;
    }




    private void HandleLanding()
    {
        var SpawnedPrefab = Instantiate(langdingParticles, Legs.position, Quaternion.identity);
        Destroy(SpawnedPrefab, langdingParticlesLifeTime);
    }

    private void Update()
    {
        HandleInput();

        HandleMovementEffects();

    }

    private void HandleMovementEffects()
    {
        if (IsMoving() && groundDetector.IsGrounded)
        {
            MoveSoundTimer += Time.deltaTime;
            if (MoveSoundTimer >= MoveSoundDelay)
            {
                MoveSoundTimer -= MoveSoundDelay;
                AudioSource.PlayClipAtPoint(MoveSound, transform.position);
                var spawnerPrefab = Instantiate(movementParticle, Legs.position, Quaternion.identity);
                Destroy(spawnerPrefab, movementParcileLifeTime);
            }
        }
    }

    private void HandleInput()
    {
        inputX = Input.GetAxis("Horizontal");

        #region cos
        if (groundDetector.IsGrounded)
        {
            isDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            if (groundDetector.IsGrounded)
            {
                isDoubleJump = true;
                isJumpingInput = true;
                AudioSource.PlayClipAtPoint(JumpSound, transform.position);

            }
            else if (isDoubleJump)
            {

                isJumpingInput = true;
                isDoubleJump = false;
                AudioSource.PlayClipAtPoint(JumpSound, transform.position);
            }




        }


        if (Input.GetKeyDown(KeyCode.S) && currentPlatform != null && groundDetector.IsGrounded)
        {
                currentPlatform.SetCollidable(false);
            
            
        } //dodaj double tap'a

        #endregion

       




    }

    #region cos2
    private void FixedUpdate()
    {
        float moveInput = inputX * Time.fixedDeltaTime * moveSpeed;
        playerRigidbody.velocity = new Vector3(moveInput, playerRigidbody.velocity.y);


        if (isJumpingInput)
        {
            float currentJumpPower = jumpPower;
            if (isDoubleJump)
            {
                currentJumpPower = DoublejumpPower;
            }

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            playerRigidbody.AddForce(new Vector3(0, currentJumpPower), ForceMode2D.Impulse);
            isJumpingInput = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {
            currentPlatform = platform;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {

            currentPlatform = null;
        }
    }

    public bool IsMoving()
    {
        return inputX != 0;
    }

    public float GetCurrentInputX()
    {
        return inputX;
    }
}

    #endregion
