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

   private int _killCounter; //temp fix. Move to WinConditions / Interfance to keep track of kills.
   private int _winCondition = 10;
   private int _collectCounter;
   private int _collectTotal;
   
   public Text scoreText;
   public Text killCount;
   public Text collectCount;

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
   
   // //Invoke("Restart", RestartDelay); //restart current scene with a slight delay. use for later. (bind enter for quick restart?)

   /*void Restart() //maybe use for later.
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restarts current scene after dying.
   }*/

   void GameOverMenu()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void KillCount()
   {
      _killCounter++;

      Debug.Log($"GOD: You've killed {_killCounter} demons! Only {(_killCounter - _winCondition)} remaining!");

      if (_killCounter + _collectCounter >= _winCondition)
      {
         Debug.Log($"GOD: You've killed {_killCounter} demons! Your work is done! Goodbye!");
        
         Invoke("VictoryMenu", restartDelay); 
      } 
   }

   public void CollectCount() //do text counter, count backwards from total amount of collectibles. 
   {
      _collectCounter++;
     
      Debug.Log($"GOD: You've collected {_collectCounter} out of {_collectTotal}");
     
     

      if (_collectCounter >= (_winCondition - 5) && _killCounter == 0) //temp fix, need new wincondition for collect.
      {
         Debug.Log($"GOD: You've collected {_collectCounter} out of {_collectTotal}. You can come back now.");
         Invoke("VictoryMenu", restartDelay); 
      }
     
   } 
   
   
   void VictoryMenu()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }
   
   

  



}
