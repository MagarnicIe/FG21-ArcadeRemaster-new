using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int _killCount = 0; //temp fix. Move to WinConditions / Interfance to keep track of kills.
    private int _collectCount = 0;
        
        
    private int _collectTotal;
    private int _winCondition = 10; //temp
   
    public Text killCountLog;
    public Text collectCountLog;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
         Collect(other.GetComponent<Collectible>());
        }
    }

    private void Collect(Collectible collectible)
    {
        if (collectible.Collect())
        {
            _collectCount++;
        }
        UpdateGUI();
    }
    
    public void KillCount()
    {
        _killCount++;
        
        Debug.Log($"GOD: You've killed {_killCount} demons! Only {(_killCount - _winCondition)} remaining!");

        if (_killCount + _collectCount >= _winCondition)
        {
            Debug.Log($"GOD: You've killed {_killCount} demons! Your work is done! Goodbye!");
        
           // Invoke("VictoryMenu", restartDelay); 
        } 
    }

    private void UpdateGUI()
    {
        collectCountLog.text = _collectCount.ToString();
        killCountLog.text = _collectCount.ToString();
    }
    
}
