using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject panel; 
    public GameObject panelPause; 
    public GameObject panelWin; 
    public Button pause;
    public Button continuer;
    public TextMeshProUGUI scoreText;
    public Button retour_1;
    public Button retour_2;
     public Button retour_3;

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
        if (retour_1 != null)
        {
            retour_1.onClick.AddListener(retourGame);
        }
        if (retour_2 != null)
        {
            retour_2.onClick.AddListener(retourGame);
        }
        if (retour_3 != null)
        {
            retour_3.onClick.AddListener(retourGame);
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
    void retourGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
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
