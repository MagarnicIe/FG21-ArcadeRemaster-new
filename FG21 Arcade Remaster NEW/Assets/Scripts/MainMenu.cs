using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //will load the next scene in queue.
   }

   public void doExitGame()
   {
      Application.Quit(); //will shut down the game when built.
       
   }
   
   public void RestartGame()
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1); //will load the next scene in queue -1
     //SceneManager.LoadScene(("Karl Scene"));
   }
   
}
