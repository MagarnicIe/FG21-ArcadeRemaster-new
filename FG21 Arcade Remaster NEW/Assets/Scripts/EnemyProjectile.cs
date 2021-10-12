using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class EnemyProjectile : PlayerProjectile
{
    
    private void OnTriggerEnter2D(Collider2D hitInfo) //stores target information when colliding with enemy.
    {
        PlayerStatus player = hitInfo.GetComponent<PlayerStatus>();
        if (player != null) //if enemy does exist then damage the enemy with damage and do an effect at bullet impact.
        {
            player.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject); //removes the bullet after impact.
    }
}


