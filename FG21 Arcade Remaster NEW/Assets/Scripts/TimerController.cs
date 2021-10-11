using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text countDownTimer;

    private TimeSpan timeRemaning;
    private bool timerGoing;

    private float _timerValue;

    private void Awake()
    {
        instance = this; //starts the timercontroller on awake.
    }

    private void Start()
    {
        countDownTimer.text = "Time: 05:00.00"; //text display layout in minutes, seconds and fraction of seconds.
        
    }

    public void BeginTimer()
    {
        timerGoing = true;
        _timerValue = 300f; // game timer in seconds.

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            _timerValue -= Time.deltaTime;
            timeRemaning = TimeSpan.FromSeconds(_timerValue);
            string timeRemainingStr = "DEATH :" + timeRemaning.ToString("mm':'ss'.'ff");
            countDownTimer.text = timeRemainingStr;

            yield return null;

            if (_timerValue <= 0)
            {
                EndTimer();
                FindObjectOfType<GameManager>().GameOver();
            }

        }
    }
    
    
}
