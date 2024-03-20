using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float CharacterJumpPower = 5f;

    public event Action OnPlayerJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Character character))
        {
            
            character.AddForce(CharacterJumpPower);
            OnPlayerJump?.Invoke();

        }
    }
}
