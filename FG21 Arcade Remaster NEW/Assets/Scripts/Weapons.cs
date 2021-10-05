using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform fireDirection;
    public GameObject bulletPrefab;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, fireDirection.position, fireDirection.rotation);
    }
}
