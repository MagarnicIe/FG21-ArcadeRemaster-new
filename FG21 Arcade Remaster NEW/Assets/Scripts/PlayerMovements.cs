using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public  class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    public int health = 100;
    public int trapDamage = 10;
    public int enemyDamage = 25;
    
    public float checkRadius;
    [SerializeField] public float speed = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    [SerializeField] private float MovementSpeed;
    private bool doubleJump;
    public LayerMask wallLayer;
    public bool isMoving;
    
    public SpriteRenderer sprite;

    private bool isTouchingWall;
    public Transform wallCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TrapHit");
        TakeDamage();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("EnemyHit");
            TakeEnemyDamage();
        }
    }
    
    private void TakeEnemyDamage()
    {
        health -= enemyDamage;
        
        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene("JesperScene");
        }
    }


    private void TakeDamage()
    {
        health -= trapDamage;
        
        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene("JesperScene");
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
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
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;



        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isTouchingWall && isGrounded == false && movement != 0)
        {
            wallSliding = true;
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

        if (!Mathf.Approximately(0, movement))
             transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        

    }
    


    //Enkelt Hoppscript
    
    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    
}
