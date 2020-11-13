using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public float points;

    [SerializeField] GameObject gameOverPanel;

   




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

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
    }
 public void QuitGame()
    {
        Application.Quit();
    }
}
