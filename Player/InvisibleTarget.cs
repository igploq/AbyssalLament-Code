using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTarget : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;  
    [SerializeField] private float moveRange = 5f;  

    private Vector3 initialPosition;
    private bool movingUp = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= initialPosition.y + moveRange)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y <= initialPosition.y - moveRange)
            {
                movingUp = true;
            }
        }
    }
}
