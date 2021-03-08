using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Sc_PlayerDeath : MonoBehaviour
{
    public GameObject countdown;
    public GameObject UI_GameEndPanel;
    public GameObject getAnimator;
    private Animator animator;
    public string isDead = "isDead";
    public float timeBeforeEndGame = 0f;
    private void Start() 
    {
        Time.timeScale = 1;
        countdown = GameObject.FindGameObjectWithTag("MainCamera");   
        animator = getAnimator.GetComponent<Animator>();
        animator.SetBool(isDead,false);        
    }
    private void Update() 
    {
        if(countdown.GetComponent<Sc_TimerCountdown>().timeRemaining <= 0)
        {
            countdown.GetComponent<Sc_TimerCountdown>().timeText.text = string.Format("{0:00}:{1:00}",0 , 0);
            animator.SetBool(isDead, true);
            timeBeforeEndGame += Time.deltaTime;
            if(timeBeforeEndGame >= 1.25)
            {
                Time.timeScale = 0;
                if(Time.timeScale < 0.01)
                {
                    UI_GameEndPanel.SetActive(true);
                }
            }
        }    
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Replay()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
