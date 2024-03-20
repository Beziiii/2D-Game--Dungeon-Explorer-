using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float momvementSpeed;
    [SerializeField] private string groundTag = "Ground";

    private void Update()
    {
        float moveValue = momvementSpeed * Time.deltaTime;
        transform.position += transform.right * moveValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag))
        {
            Destroy(gameObject);
        }
       else  if (collision.TryGetComponent(out Health health))
        {
            //health.Damage(1);
            Destroy(gameObject);
        }

    }
    }




