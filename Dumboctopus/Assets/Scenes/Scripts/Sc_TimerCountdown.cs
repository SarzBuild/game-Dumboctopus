using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_TimerCountdown : MonoBehaviour
{
    public float timeRemaining;
    public float maxTime = 211;
    public bool timerIsRunning = false;
    public Text timeText;
    public Slider slider;
    public float seconds;
    private void Start()
    {
        timerIsRunning = true;
        timeRemaining = maxTime;
    }


    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        UpdateSlider();
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateSlider ()
    {

        slider.value = timeRemaining / maxTime;
    }
    public void AddTime(float timeToAdd)
    {
        if (timeRemaining <= (maxTime - timeToAdd))
        {
            timeRemaining += timeToAdd;
        }
        else
        {
            timeRemaining = maxTime;
        }
        
    }
}
