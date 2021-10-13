using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFOLLOWTEST : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float lineOfSite;
    public Animator animator;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( player != null)
        {
            CheckForPlayer();
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
    }

    private void CheckForPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite)
        {
            animator.SetBool("moving", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    
    
}
