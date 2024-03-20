using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private BoxCollider2D BoxCollider;

    private bool isCollidable;

    public void SetCollidable(bool isCollidable)
    {
        this.isCollidable = isCollidable;
        BoxCollider.enabled = isCollidable;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Character character))
        {
            SetCollidable(true);
        }
    }
}
