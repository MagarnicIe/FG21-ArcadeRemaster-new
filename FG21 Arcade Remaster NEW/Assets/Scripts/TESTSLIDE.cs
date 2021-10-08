using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSLIDE : MonoBehaviour
{
    private bool moving;
    private int currentDirection;

    private float speed;
    private float boostTimer;
    private bool boosting;

    void Start()
    {
        moving = false;
        currentDirection = 1;

        speed = 5;
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HorizontalMove(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))

        {
            HorizontalMove(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            HorizontalStay();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            HorizontalStay();
        }

        if (moving)
        {
            this.transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
        }
        
        if (!Input.GetKeyDown(KeyCode.LeftShift)) return;
        {
            boosting = true;
            speed = 15;

            if (!boosting) return;
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1)
            {
                speed = 1;
                boostTimer = 0;
                boosting = false;
            }
        }
        
        


    }

    private void HorizontalStay()
    {
        moving = false;
    }

    private void HorizontalMove(int direction)
    {
        moving = true;

        if (currentDirection < 0 && direction > 0)
        {
            currentDirection = 1;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (currentDirection > 0 && direction < 0)
        {
            currentDirection = -1;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

    }
    
}
