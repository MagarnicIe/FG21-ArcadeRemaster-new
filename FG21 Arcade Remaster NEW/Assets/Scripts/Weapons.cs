using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform fireDirection;
    public Transform firePoint;
    
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
        
        /*Vector3 fireDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (fireDirection.x<transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }*/

       
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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //spawns the bullet   
            Destroy(bullet, 1); //destroys the bullet after 1sec.
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
