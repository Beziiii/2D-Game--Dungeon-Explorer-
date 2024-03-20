using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private AudioClip PickupSound;
    [SerializeField] private GameObject OpenChestAnim;
    [SerializeField] private float OpenChestAnimTime = 0.3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Pouch pouch))
        {
            pouch.AddTreasure();


            var SpawnerPrefab = Instantiate(OpenChestAnim, transform.position, Quaternion.identity);
            Destroy(SpawnerPrefab, 0.8f);

            AudioSource.PlayClipAtPoint(PickupSound, transform.position);
            Destroy(gameObject);

            
        }
    }
}
