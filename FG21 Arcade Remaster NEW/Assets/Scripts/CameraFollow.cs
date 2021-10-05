using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float timeOffSet;
    [SerializeField] private Vector3 offSetPos;

   //[SerializeField] private Vector3 boundMin;
   //[SerializeField] private Vector3 boundMax;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 startPos = transform.position;
            Vector3 targetPos = player.position;

            targetPos.x += offSetPos.x;
            targetPos.y += offSetPos.y;
            targetPos.z = transform.position.z;

            //targetPos.x = Mathf.Clamp(targetPos.x, boundMin.x, boundMax.x);
            //targetPos.y = Mathf.Clamp(targetPos.y, boundMin.y, boundMax.y);

            float t = 1f - Mathf.Pow(1f - timeOffSet, Time.deltaTime * 30);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

        } 
    }
}