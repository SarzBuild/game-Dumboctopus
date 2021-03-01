using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_LavaCollision : MonoBehaviour
{
    public GameObject countdown;
    public bool inLava = false;
    public int internalTimer;
    public float timeSinceLastDamage;
    private void Start() 
    {
        countdown = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            inLava = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            inLava = false;
        }
    }
    public void TimeBeforeGettingHurt()
    {
        if(timeSinceLastDamage > 1.0f)
        {
            timeSinceLastDamage = 0f;
            countdown.GetComponent<Sc_TimerCountdown>().timeRemaining -= 5;
        }
        else
        {
            timeSinceLastDamage += Time.deltaTime;
        }
    }
    void Update()
    {
        if(inLava)
        {
            TimeBeforeGettingHurt();
        }
        else
        {
            timeSinceLastDamage = 1.0f;
        }
    }
    
}
