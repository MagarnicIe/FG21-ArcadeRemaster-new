using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyRanged : Enemy
{
    public GameObject enemyProjectile;
    public Transform fireDirection;
    
    

    public override void Update()
    {
        atkCooldown -= Time.deltaTime;
        if (atkCooldown <= 0)
        {
            Instantiate(enemyProjectile, fireDirection.position, fireDirection.rotation);
            atkCooldown = atkSpeed;
            
        }
        
    }
}
