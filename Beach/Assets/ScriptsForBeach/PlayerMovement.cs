using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed = 10.0f;
    public float turnSpeed = 10.0f;
    public float xRange = 15.0f;
    public bool isJumping;
    public bool isRunning;
    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // BOUNDRY


        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // MOVEMENT
        movement = new Vector3(horizontalInput, 0.0f, forwardInput);
        if (movement.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * -speed * Time.deltaTime);
        //JUMP
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetBool("isJumping", true);
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("isJumping", false);
            
        }
    }
}
