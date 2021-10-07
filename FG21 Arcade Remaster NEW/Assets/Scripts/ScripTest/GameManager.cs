using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   private bool gameIsOver = false; //default to false to access method as soon as we die.

   public float restartDelay = 3f;

   public float gameOverDelay = 600f; //10min game over delay.

   public void Start()
   {
     EndGameTimer(); //starts a timer at start of the game scene, calls Game over after 10min have passed.
   }

   public void EndGameTimer()
   {
      Invoke("GameOverMenu", gameOverDelay);
   }

   public void GameOver()
   {
      if (gameIsOver == false) 
      {
         gameIsOver = true; //sets game is over to true so we cannot access it again to avoid spam.

         //Invoke("Restart", RestartDelay); //restart current scene with a slight delay.
         Invoke("GameOverMenu", restartDelay);
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
