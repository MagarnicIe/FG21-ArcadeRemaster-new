using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    public int health = 100;
    public int enemyDamage = 50;
    public int trapDamage = 20;
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
            
        }
    }

    private void TakeDamage()
    {
        health -= trapDamage;
        
        if (health <= 0)
        {
            Die();
            
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
