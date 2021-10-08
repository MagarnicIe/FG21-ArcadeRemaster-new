using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Traps : MonoBehaviour
{
    public int damage = 20;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{name} Triggered");
            collision.GetComponent<PlayerStatus>().TakeDamage(damage);
        }
        
        
    }
}
