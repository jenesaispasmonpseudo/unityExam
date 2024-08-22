using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManagement : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Assurez-vous que vous utilisez TextMeshProUGUI pour les éléments UI
    private float timerDuration = 30f; // Durée du timer en secondes
    private float currentTime; // Temps restant

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timerDuration;
        UpdateTimerUI();
        Debug.Log("Le timer commence à : " + currentTime + " secondes");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; 
            UpdateTimerUI();
        }
        else
        {
            
            currentTime = 0;
            Debug.Log("Le timer est terminé!");
            UpdateTimerUI();
            Time.timeScale = 0f;
        }
    }

    void UpdateTimerUI()
    {
        textMeshPro.text = Mathf.Ceil(currentTime).ToString();
    }
}
