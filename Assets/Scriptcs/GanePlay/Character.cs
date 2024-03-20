using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{


    [SerializeField] private Rigidbody2D CharacterRigidbody;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy2")
        {

            //Health.health--;
            //if (Health.health <= 0)
            //{

            //    gameObject.SetActive(false);
            //}
            //else
            //{

            //    StartCoroutine(GetHurt());
            //}
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3, 9);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(3, 9, false);
    }

    public void AddForce(float force)

    {
        CharacterRigidbody.velocity = new Vector2(CharacterRigidbody.velocity.x, 0);
        CharacterRigidbody.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }


}









