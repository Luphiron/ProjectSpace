using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    void Update()
    {

    }

    public void AddScore50()
    {
        score += 50;
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void AddScore100()
    {
        score += 100;
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    public void AddScore200()
    {
        score += 200;
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void LoseScore50()
    {
        score -= 50;
        score = Mathf.Max(score, 0);
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void LoseScore25()
    {
        score -= 25;
        score = Mathf.Max(score, 0);
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
