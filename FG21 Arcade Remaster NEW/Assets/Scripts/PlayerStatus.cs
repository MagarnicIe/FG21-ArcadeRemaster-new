using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
    
    
    public int health = 3;
    
    
    public GameObject deathEffect;
    
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
        
        void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
