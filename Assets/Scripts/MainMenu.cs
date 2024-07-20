using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

