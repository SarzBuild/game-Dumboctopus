using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_LeverControl : MonoBehaviour
{
    [SerializeField] Sc_Platform platform;
    [SerializeField] GameObject textGameObject;

    private Animator platformAnimator;
    private KeyCode inputAction = KeyCode.E;
    public bool isOnTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        platformAnimator = platform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateLever();
        if (isOnTrigger)
        {
            textGameObject.SetActive(true);
        }
        else
        {
            textGameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTrigger = false;
    }
    private void ActivateLever()
    {
        if (isOnTrigger)
        {
            if (Input.GetKeyUp(inputAction) && platformAnimator.enabled == false)
            {
                Debug.Log("Pressing E");
                platformAnimator.enabled = true;
            }
            else if (Input.GetKeyUp(inputAction) && platformAnimator.enabled == true)
            {
                Debug.Log("Pressing G");
                platformAnimator.enabled = false;
            }
        }
        
    }
        
}
