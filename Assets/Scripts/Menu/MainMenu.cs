using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup mainMenu = default;
    [SerializeField] CanvasGroup controlsMenu = default;
    [SerializeField] CanvasGroup creditsMenu = default;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToControls()
    {
        ShowView(controlsMenu);
        HideView(mainMenu);
    }

    public void GoToMainMenu()
    {
        ShowView(mainMenu);
        HideView(controlsMenu);
        HideView(creditsMenu);
    }

    public void GoToCredits()
    {
        ShowView(creditsMenu);
        HideView(mainMenu);
    }

    private void ShowView(CanvasGroup group)
    {
        group.alpha = 1f;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    private void HideView(CanvasGroup group)
    {
        group.alpha = 0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
}
