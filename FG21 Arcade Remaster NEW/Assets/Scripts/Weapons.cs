using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform fireDirection;
    public GameObject bulletPrefab;
    
    public GameObject meleeImpactEffect;

    public float atkSpeed = 0.05f;
    public float atkCooldown = 0;

    public int meleeDmg = 100;
    public float meleeRange = 1f;
    public LayerMask enemyLayers;
    
    void Update()
    {
        atkCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) //left mouse button
        {
            Shoot();
        }
        else if (Input.GetMouseButtonDown(1)) //right mouse button
        {
            Melee();
        }
        
    }

    void Shoot()
    {
        if (atkCooldown <= 0)
        {
            Instantiate(bulletPrefab, fireDirection.position, fireDirection.rotation); //spawns the bullet    
            atkCooldown = atkSpeed;
        }
    }

    void Melee()
    {
        //animator.SetTrigger("Melee"); animation trigger used for future animation when striking. 
        Collider2D[] meleeHitEnemies = Physics2D.OverlapCircleAll(fireDirection.position, meleeRange, enemyLayers);
        

        foreach (Collider2D enemy in meleeHitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(meleeDmg);
            Instantiate(meleeImpactEffect, enemy.transform.position, transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (fireDirection == null) //removes error / breaking if fireDirection lacks reference.
            return;
        Gizmos.DrawWireSphere(fireDirection.position, meleeRange); //displays melee range in unity.
        
    }
}
