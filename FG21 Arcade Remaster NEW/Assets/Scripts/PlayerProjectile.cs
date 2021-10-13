using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 30f;
    
    public int damage = 25;
    public GameObject impactEffect;

    private void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) //stores target information when colliding with enemy.
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) //if enemy does exist then damage the enemy with damage and do an effect at bullet impact.
        {
            enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject, 0.01f);
        }

        Destroy(gameObject, 0.01f);
    }
}
