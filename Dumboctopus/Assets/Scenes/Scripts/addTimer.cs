 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTimer : MonoBehaviour
{
    Sc_TimerCountdown sc_TimerCountdown;
    public float timeToAdd = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        sc_TimerCountdown = FindObjectOfType<Sc_TimerCountdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("AddTimer"))
        {
            sc_TimerCountdown.AddTime(timeToAdd);
            Destroy(gameObject);
        }        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Water"))
        {
            sc_TimerCountdown.AddTime(timeToAdd);
        }
    }
}
