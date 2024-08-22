using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject panel; 
    public GameObject panelPause; 
    public GameObject panelWin; 
    public Button pause;
    public Button continuer;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); 
        }
        if (panelWin != null)
        {
            panelWin.SetActive(false); 
        }
        if (panelPause != null)
        {
            panelPause.SetActive(false); 
        }

        if (pause != null)
        {
            pause.onClick.AddListener(PauseGame);
        }

        if (continuer != null)
        {
            continuer.onClick.AddListener(ContinueGame);
        }

    }

    void Update()
    {
        if (scoreText != null)
        {
            string scoreString = scoreText.text;
            if (scoreString == "0")
            {
                if (panel != null)
                {
                    panel.SetActive(true);
                }
            }
            else
            {
                if (panel != null)
                {
                    panel.SetActive(false);
                }
            }
        }
    }

    void PauseGame()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;

    }
    void ContinueGame(){
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}
