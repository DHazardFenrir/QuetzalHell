using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasGroup pauseMenu = default;
    [SerializeField] CanvasGroup gameOverMenu = default;

    private bool isPaused = false;
    private bool isInGameOver = false;

    public static GameManager Instance;
   
    public float points;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isInGameOver)
        {
            if(!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isInGameOver)
        {
            return;
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.alpha = (1f);
        pauseMenu.interactable = true;
        pauseMenu.blocksRaycasts = false;

    }
    
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.alpha = (0f);
        pauseMenu.interactable = false;
        pauseMenu.blocksRaycasts = true;
    }

    public void ShowGameOver()
    {
        isInGameOver = true;
        Time.timeScale = 0f;
        gameOverMenu.alpha = 1f;
        gameOverMenu.interactable = true;
        gameOverMenu.blocksRaycasts = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level01");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
