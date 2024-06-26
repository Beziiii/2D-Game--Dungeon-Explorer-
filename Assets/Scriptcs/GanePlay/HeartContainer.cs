using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainer : MonoBehaviour
{

    public int health;
    public int maxHealth;

    public Image[] hearts;

    public Sprite FullHeart;

    public Sprite EmptyHeart;

    public Health CharacterHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = CharacterHealth.health;
        maxHealth = CharacterHealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHeart;

            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
