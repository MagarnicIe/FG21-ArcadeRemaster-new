using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStatus : MonoBehaviour
{
    
    
    public int health = 5;

    public GameObject dmgScreenEffect;
    
    public GameObject deathEffect;
    
    
    
    
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        var color = dmgScreenEffect.GetComponent<Image>().color;
        color.a = 0.7f;

        dmgScreenEffect.GetComponent<Image>().color = color;
        
         
        
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

    private void Update()
    {
        if (dmgScreenEffect.GetComponent<Image>().color.a > 0)
        {
            var color = dmgScreenEffect.GetComponent<Image>().color;
            color.a -= 0.01f;
            dmgScreenEffect.GetComponent<Image>().color = color;
        }
    }
}
