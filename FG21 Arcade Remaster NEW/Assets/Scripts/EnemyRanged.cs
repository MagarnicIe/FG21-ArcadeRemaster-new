using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyRanged : Enemy
{
    public GameObject enemyProjectile;
    public Transform fireDirection;
    public Transform player;
    public float lineOfSite;
    
    

    public override void Update()
    {
        if (player != null)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            atkCooldown -= Time.deltaTime;
            if (atkCooldown <= 0)
            {
                if (distanceFromPlayer < lineOfSite)
                {
                    GameObject enemyProjectiles = Instantiate(enemyProjectile, fireDirection.position, fireDirection.rotation);
                    Destroy(enemyProjectiles, 3); //destroys the bullet after 1sec.
                }

                atkCooldown = atkSpeed;
            }

        }
        
    }
}
