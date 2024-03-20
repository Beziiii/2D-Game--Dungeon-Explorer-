using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public static Action OnPlayerDeath;
    public GameObject GameOverPanel;

    public int health;
    public int maxHealth = 3;

    public SpriteRenderer PlayerSprite;
    public CharacterMovemnet PlayerMove;

    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if( health <= 0)
        {
           PlayerSprite.enabled = false;
            PlayerMove.enabled = false;
            GameOverPanel.SetActive(true);
        }
    }








}
