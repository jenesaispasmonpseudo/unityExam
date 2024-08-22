using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditController : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
         backButton.onClick.AddListener(OnBackButton);
    }

    private void OnBackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
