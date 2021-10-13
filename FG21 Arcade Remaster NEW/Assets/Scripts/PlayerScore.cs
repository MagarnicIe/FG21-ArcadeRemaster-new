using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int _killCount = 0; //temp fix. Move to WinConditions / Interfance to keep track of kills.
    private int _collectCount = 0;
    public float _scoreCount = 0;
        
    
    private int _winConditionKills = 10; //temp
    private int _winConditionCollects = 5;
   
    public Text killCountLog;
    public Text collectCountLog;
    public Text scoreCountLog;

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
            _scoreCount +=100;
            _collectCount++;
            UpdateGUI();

            if (_collectCount >= _winConditionCollects) 
            {
                //FindObjectOfType<GameManager>().VictoryPacifist();
                FindObjectOfType<GameManager>().Victory();
            }
        }
        
    }
    
    public void KillCount()
    {
        _scoreCount +=50;
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
        collectCountLog.text = "Collects :" + _collectCount.ToString() + "  / " + _winConditionCollects;
        killCountLog.text = "Kills :" + _killCount.ToString() + " / " + _winConditionKills;
        scoreCountLog.text = "Score: " + _scoreCount;
    }
    
}
