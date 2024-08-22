using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManegeScript : MonoBehaviour
{
    public Button jouer;
    public Button quitter;
    public Button credit;
    void LoadGameScene()
    {
        SceneManager.LoadScene("game"); 
    }

    // Méthode pour quitter l'application
    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #else
        Application.Quit(); 
        #endif
    }

    // Méthode pour charger la scène des crédits
    void LoadCreditsScene()
    {
        SceneManager.LoadScene("credit"); 
    }


    // Start is called before the first frame update
    void Start()
    {
        
        jouer.onClick.AddListener(LoadGameScene);
        quitter.onClick.AddListener(QuitGame);
        credit.onClick.AddListener(LoadCreditsScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
