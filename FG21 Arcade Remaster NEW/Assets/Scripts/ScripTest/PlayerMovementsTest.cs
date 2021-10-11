using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public  class PlayerMovementsTest : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]public float jumpForce;

    private AudioSource jumpsound;
    
    private bool isGrounded;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    [SerializeField] private float MovementSpeed;
    private bool doubleJump;
    public LayerMask wallLayer;

    private bool isTouchingWall;
    public Transform wallCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsound = GetComponent<AudioSource>();

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
                Jump();
                doubleJump = false;
            }
            if (isTouchingWall)
            {
                doubleJump = true;
            }

        }
        
    }

    private void FixedUpdate()
    {

       isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, wallLayer);
        
        var movement =  Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
       
       if (isTouchingWall && isGrounded == false && movement != 0)
       {
          wallSliding = true;
           doubleJump = true;
       }
       else
       {
           wallSliding = false;
       }

       if (wallSliding)
       {
           var velocity = rb.velocity;
           rb.velocity = new Vector2(velocity.x, Mathf.Clamp(velocity.y, -wallSlidingSpeed, float.MaxValue));
       }
//
    
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
    
    
    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        jumpsound.Play();
    }
    
    
    
}