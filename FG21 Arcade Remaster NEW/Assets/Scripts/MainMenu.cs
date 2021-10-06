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

   public void ExitGame()
   {
      Application.Quit(); //will shut down the game when built.
      Debug.Log("Exiting game..."); //temp debug to test menu exiting function. Should be deleted before final build.
      
   }
   
   
}
