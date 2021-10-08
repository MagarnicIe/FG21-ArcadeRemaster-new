using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

         Invoke("GameOverMenu", restartDelay);
      }
   }

   public void Victory()
   {
      if (gameIsOver == false)
      {
         gameIsOver = true;

         Invoke("VictoryMenu", restartDelay);
      }
   }
   
   public void VictoryPacifist()
   {
      if ((gameIsOver == false))
      {
         gameIsOver = true;
         
         Invoke("VictoryMenuPacifist", restartDelay);
      }
   }
   
   // //Invoke("Restart", RestartDelay); //restart current scene with a slight delay. use for later. (bind enter for quick restart?)
   
   void GameOverMenu()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   private void VictoryMenu()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }

   private void VictoryMenuPacifist()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
   }
   
}
