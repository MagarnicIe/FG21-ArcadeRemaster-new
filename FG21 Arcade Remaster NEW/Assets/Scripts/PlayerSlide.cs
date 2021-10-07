using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public bool isSliding = false;
    public PlayerMovements PM;
    
    public Rigidbody2D rb;

    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;

    public float slideSpeed = 5f;
    
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            preformSlide();
    }

    public void preformSlide()
    {
        isSliding = true;
        regularColl.enabled = false;
        slideColl.enabled = true;
        
        rb.AddForce(Vector2.right * slideSpeed);
    }
}
