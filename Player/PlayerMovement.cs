using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] public float moveSpeed = 10.0f;
    [SerializeField] public float strafeSpeed = 7.0f;
    [SerializeField] public float jumpForce = 10.0f;
    [SerializeField] public float gravity = 20.0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    [SerializeField] private GameObject deathPrefab;
    private ScoreManager scoreManager;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    private void Update()
    {
        HandleMovement();
        HandleGravity();
        HandleJump();

        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleMovement()
    {

        float forwardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");


        Vector3 forwardMovement = transform.forward * forwardInput * moveSpeed;
        Vector3 strafeMovement = transform.right * strafeInput * strafeSpeed;


        velocity.x = (forwardMovement + strafeMovement).x;
        velocity.z = (forwardMovement + strafeMovement).z;
    }

    private void HandleGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        isGrounded = controller.isGrounded;
    }

    private void HandleJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            scoreManager.SaveHighscore();
            Destroy(gameObject);

            Vector3 spawnOffset = new Vector3(0, 5, 0);
            Vector3 spawnPoint = transform.position + spawnOffset;

            Quaternion spawnRotation = Quaternion.Euler(90, 0, 0);
            Instantiate(deathPrefab, spawnPoint, spawnRotation);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }


}
