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
    public Animator animator;
    private bool isGrounded;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform enemyCheck;
    public LayerMask enemyLayer;
    
    [SerializeField] private float MovementSpeed;
    private bool doubleJump;
    public LayerMask wallLayer;
    private float movement = 0f;
    private bool isTouchingWall;
    private bool onEnemy;
    public Transform wallCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsound = GetComponent<AudioSource>();

    }
    
    void Update()
    {
        onEnemy = Physics2D.OverlapCircle(enemyCheck.position, checkRadius, enemyLayer);
        
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

            if (onEnemy)
                doubleJump = true;

        }
        
    }

    private void FixedUpdate()
    {

       isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, wallLayer);
      

       animator.SetFloat("MovementSpeed", Mathf.Abs(movement));

       movement = Input.GetAxisRaw("Horizontal");
        if (isTouchingWall == false)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        }
       
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

       if (isGrounded)
       {
           animator.SetBool(IsJumping, false);
       }
//
    
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
    
    
    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        animator.SetBool(IsJumping, true);
        jumpsound.Play();
        
    }
    
    
    
}