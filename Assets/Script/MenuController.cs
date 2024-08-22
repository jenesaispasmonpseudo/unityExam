using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button creditsButton;
    public Button playButton;
    public Button leftButton;

    void Start()
    {
        creditsButton.onClick.AddListener(OnCreditsButtonClick);
        playButton.onClick.AddListener(OnPlayButtonClick);
        leftButton.onClick.AddListener(OnLeftButtonClick);
    }

    private void OnCreditsButtonClick()
    {
        SceneManager.LoadScene("credit");
    }
    private void OnPlayButtonClick()
    {
         SceneManager.LoadScene("game");
    }
    void OnLeftButtonClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
