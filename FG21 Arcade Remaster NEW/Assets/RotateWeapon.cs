using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class RotateWeapon : MonoBehaviour
{
    
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 weaponPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - weaponPosition.x;
        mousepos.y = mousepos.y - weaponPosition.y;
        float weaponAngle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;

        if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x<transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -weaponAngle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, weaponAngle));
        }
    }
} 
