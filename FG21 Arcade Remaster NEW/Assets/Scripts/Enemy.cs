using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;
    public GameObject hitEffect;
    
    public LayerMask playerLayer;

    private int range = 1;
    private int damage = 25;
    private int atkSpeed = 1;

    private float atkCooldown;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }
    
    void Update()
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
    
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
