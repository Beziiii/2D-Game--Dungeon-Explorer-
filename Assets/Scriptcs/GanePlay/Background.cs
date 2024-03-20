using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float MovementSpeed = 1f;

    private bool isMovingUp;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
       
        float moveValue = MovementSpeed * Time.deltaTime;
        if (isMovingUp)
        {
            Vector3 targetPostion = startingPosition + new Vector3(0, maxY);

            transform.position = Vector3.MoveTowards(transform.position,targetPostion, moveValue);
            if (transform.position == targetPostion)
            {
                isMovingUp = false;
            }
        }
        else
        {
            Vector3 targetPostion = startingPosition + new Vector3(0, minY);

            transform.position = Vector3.MoveTowards(transform.position, targetPostion, moveValue);
            if(transform.position == targetPostion)
            {
                isMovingUp=true;
            }
        }
    }

}
