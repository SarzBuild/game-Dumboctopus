using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_Endgame : MonoBehaviour
{
    public GameObject UI_GameEndPanel;
    public GameObject getPlayerControl;
    private Sc_PlayerControls playerControls;
    public GameObject getMainText;
    public GameObject getSubText;
    private Text mainText;
    private Text subText;
    // Start is called before the first frame update
    void Awake()
    {
        mainText = getMainText.GetComponent<Text>();
        subText = getSubText.GetComponent<Text>();
        playerControls = getPlayerControl.GetComponent<Sc_PlayerControls>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        mainText.text = "Congratulations!";
        subText.text = "You have escaped";
        UI_GameEndPanel.SetActive(true);
        playerControls.enabled = false;
        Time.timeScale = 0;
    }
}
