using System;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private bool gameIsOver = false; //default to false to access method as soon as we die.

   public float restartDelay = 0.01f;

   //private bool gamePlaying;
   
   public void Start()
   {
      //gamePlaying = true;
      TimerController.instance.BeginTimer(); //starts the ingame countdown.
   }

   public void Update()
   {
      if (Input.GetKeyDown(KeyCode.R))
      {
         GameRestart();
      }
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

   void GameRestart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   
}
