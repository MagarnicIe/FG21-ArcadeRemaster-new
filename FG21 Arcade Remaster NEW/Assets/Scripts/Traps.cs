using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
[RequireComponent(typeof(TilemapCollider2D))]
public class Traps : MonoBehaviour
{
    
    private void Reset()
    {
        GetComponent<TilemapCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{name} Triggered");
        }
    }
}
