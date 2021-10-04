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
    [SerializeField] private float groundDistance = 0.6f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject pause;
    [SerializeField] private bool isPause;

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
        if(Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            isPause = true;
        }    
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            isPause = false;
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
        if(velocity.y < -40.0f)
        {
            Lose();
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
        if(collision.GetComponent<Bullet>() || collision.GetComponent<GreatDestroyer>())
        {
            Lose();
        }
        if(collision.GetComponent<Win>())
        {
            Win();
        }
    }

    private void Lose()
    {
        Debug.Log("Lose");
        controller.enabled = false;
        this.transform.position = Vector3.one + Vector3.right * 14;
        this.transform.rotation = Quaternion.LookRotation(Vector3.right * 100);
        Time.timeScale = 0f;
        lose.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Win()
    {
        Debug.Log("Win");
        controller.enabled = false;
        this.transform.position = Vector3.one + Vector3.right * 14;
        this.transform.rotation = Quaternion.LookRotation(Vector3.right * 100);
        Time.timeScale = 0f;
        win.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
