using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FinalScore;

    public void Start()
    {
    }

    public void GameOverScreen(int score)
    {
        gameObject.SetActive(true);
        FinalScore.text = scoreText.text;

        scoreText.gameObject.SetActive(false);
    }
}
