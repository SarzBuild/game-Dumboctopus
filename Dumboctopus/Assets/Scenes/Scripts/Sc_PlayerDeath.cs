using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sc_PlayerDeath : MonoBehaviour
{
    public GameObject countdown;
    public GameObject UI_GameEndPanel;
    private void Start() 
    {
        Time.timeScale = 1;
        countdown = GameObject.FindGameObjectWithTag("MainCamera");   
    }
    private void Update() 
    {
        if(countdown.GetComponent<Sc_TimerCountdown>().timeRemaining <= 0)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.03f);
            if(Time.timeScale < 0.01)
            {
                UI_GameEndPanel.SetActive(true);
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
