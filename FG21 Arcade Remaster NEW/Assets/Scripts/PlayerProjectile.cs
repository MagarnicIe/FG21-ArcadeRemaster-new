using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    public int damage = 25;
    public GameObject impactEffect;
    
    void Start()
    {
        rb.velocity = transform.right * speed; //when bullet spawn it will travel the same direction as the player with its own speed.
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) //stores target information when colliding with enemy.
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) //if enemy does exist then damage the enemy with damage and do an effect at bullet impact.
        {
            enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject); //removes the bullet after impact.
    }
}
