using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{

   private bool isCollected = false;
   //private AudioSource collected;

   public bool Collect()
   {
      if (isCollected)
      {
         return false;
      }

      isCollected = true;
      //collected.Play();
      Destroy(gameObject,(float) 0.1); //removes object as soon as collected.
      return true;
   }
}
