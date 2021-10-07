using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   private bool gameIsOver = false; //default to false to access method as soon as we die.

   public float RestartDelay = 3f;

   public void GameOver()
   {
      if (gameIsOver == false) 
      {
         gameIsOver = true; //sets game is over to true so we cannot access it again to avoid spam.

         //Invoke("Restart", RestartDelay); //restart current scene with a slight delay.
         Invoke("GameOverMenu", RestartDelay);
      }
   } 
   
   /*void Restart() //maybe use for later.
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restarts current scene after dying.
   }*/

   void GameOverMenu()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

}
