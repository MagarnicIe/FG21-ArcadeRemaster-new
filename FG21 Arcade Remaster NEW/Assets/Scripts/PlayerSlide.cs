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

    public float slideSpeed = 50f;
    
    public float movement =  Input.GetAxisRaw("Horizontal");


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            performSlideRight();

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            performSlideLeft();

    }

    public void performSlideRight()
    {
        isSliding = true;
        regularColl.enabled = false;
        slideColl.enabled = true;
        
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * slideSpeed;
    }

    public void performSlideLeft()
    {
        isSliding = true;
        regularColl.enabled = false;
        slideColl.enabled = true;
        
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * slideSpeed;
    }
}
