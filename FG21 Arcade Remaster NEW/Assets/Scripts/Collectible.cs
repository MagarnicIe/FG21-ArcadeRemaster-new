using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{

   private bool isCollected = false;

   public bool Collect()
   {
      if (isCollected)
      {
         return false;
      }

      isCollected = true;
      Destroy(gameObject); //removes object as soon as collected.
      return true;
   }
}
