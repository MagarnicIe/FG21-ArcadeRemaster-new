using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;
    [SerializeField] private float MovementSpeed;
    private bool doubleJump;

    private bool isTouchingWall;
    public Transform wallCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jumpForce = jumpForce;
                Jump();
                doubleJump = false;
                jumpForce = jumpForce;
            }
            
        }
        
        

        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isTouchingWall == true && isGrounded == false && movement != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
