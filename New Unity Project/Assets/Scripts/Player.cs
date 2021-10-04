using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField] private float gravity;
    private Vector3 velocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight;

    public float speed;

    public float inverted = 1;

    void Update()
    {
        Move();
        Gravity();
        Grounded();
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * inverted; //A and D buttons
        float z = Input.GetAxis("Vertical") * inverted; //W and S buttons

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
    void Grounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<Bullet>())
        {
            Lose();
        }
    }

    private void Lose()
    {

    }
    private void Win()
    {

    }
}
