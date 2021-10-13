using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
    
    
    public int health = 5;
    
    
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
            Destroy (gameObject, (float) 0.1); //destroys the game object with a slight delay so other scripts can get hp etc.
            
        }
    }
}
