using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
public void GameOver()
    {
        NewEnemies.instance.enemiesKilled = 0;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
