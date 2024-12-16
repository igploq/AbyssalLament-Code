using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float homingAccuracy = 5f;

    private bool isChasing = true;

    private Rigidbody rb;

    private void Start()
    {
        if (target == null)
        {

            target = GameObject.Find("InvisibleTarget")?.transform;

            if (target == null)
            {
                Debug.LogError("Invisible Target not found in the scene!");
            }
        }


        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }


        rb.useGravity = false;


        if (GetComponent<Collider>() == null)
        {

            SphereCollider collider = gameObject.AddComponent<SphereCollider>();
            collider.radius = 1f;
            collider.isTrigger = false;
        }
    }
        private void FixedUpdate()
        {
            if (target == null) return;


            if (isChasing)
            {

                HomingMovement();
            }
            else
            {

                MoveInStraightLine();
            }
        }


        private void HomingMovement()
        {

            Vector3 direction = (target.position - transform.position).normalized;


            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            rb.velocity = direction * speed;
        }


        private void MoveInStraightLine()
        {

            rb.velocity = transform.forward * speed;


            transform.Rotate(Vector3.up, homingAccuracy * Time.deltaTime);
        }
    }

