using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int _killCount = 0; //temp fix. Move to WinConditions / Interfance to keep track of kills.
    private int _collectCount = 0;
        
        
    private int _collectTotal;
    private int _winConditionKills = 10; //temp
    private int _winConditionCollects = 5;
   
    public Text killCountLog;
    public Text collectCountLog;

    private void Start()
    {
        UpdateGUI();
    }

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
            UpdateGUI();

            if (_collectCount >= _winConditionCollects && _killCount <= 0) 
            {
                FindObjectOfType<GameManager>().VictoryPacifist();
            }
        }
        
    }
    
    public void KillCount()
    {
        _killCount++;
        UpdateGUI();
        
        //Debug.Log($"GOD: You've killed {_killCount} demons! Only {(_killCount - _winCondition)} remaining!");

        if (_killCount >= _winConditionKills)
        {
            Debug.Log($"GOD: You've killed {_killCount} demons! Your work is done! Goodbye!");
            
            FindObjectOfType<GameManager>().Victory();
        } 
    }

    private void UpdateGUI()
    {
        //collectCountLog.text = _collectCount.ToString();
        //killCountLog.text = _killCount.ToString();
        
        collectCountLog.text = "Collects :" + _collectCount.ToString() + "  / " + _winConditionCollects;
        killCountLog.text = "Kills :" + _killCount.ToString() + " / " + _winConditionKills;
        
        
    }
    
}