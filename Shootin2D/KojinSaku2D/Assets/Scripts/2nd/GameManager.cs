using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject gameOver;

    public int scoreIG;
    public int score;
    public Text scoreText;
    public Text highScoreText;
    public Text scoreIGText;

    private void Awake()
    {
        manager = this;
    }

    public void Start()
    {
        scoreIGText.text = "Score : " + scoreIG.ToString();
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreIG += amount;
        scoreIGText.text = "Score : " + scoreIG.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("2nd");
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        scoreText.text = "Score : " + score.ToString();
        HighScore();
        UpdateHighScore();
    }

    public void HighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void UpdateHighScore()
    {
        highScoreText.text = $"HighScore : {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
