using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHealth = 1;

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }


    }
}

