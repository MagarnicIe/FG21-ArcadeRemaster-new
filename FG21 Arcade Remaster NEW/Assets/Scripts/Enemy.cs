using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;
    public GameObject hitEffect;
    private AudioSource gethitSound;
    
    public LayerMask playerLayer;

    public int range;
    public int damage;
    public int atkSpeed;

    public float atkCooldown;

    public void Start()
    {
        gethitSound = GetComponent<AudioSource>();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        gethitSound.Play();
        
        if (health <= 0) 
        {
            FindObjectOfType<PlayerScore>().KillCount();
            
            Die();
        }
    }

    public virtual void Update()
    {
        //animator.SetTrigger("Attack"); animation trigger used for future animation when striking. 
        Collider2D[] enemyHitPlayer = Physics2D.OverlapCircleAll(transform.position, range, playerLayer);
        
        atkCooldown -= Time.deltaTime;
        
        foreach (Collider2D player in enemyHitPlayer)
        {
            if (atkCooldown <= 0)
            {
                player.GetComponent<PlayerStatus>().TakeDamage(damage);
                Instantiate(hitEffect, player.transform.position, transform.rotation);
                atkCooldown = atkSpeed;
            }
        }
    }
    
    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    
}
