using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        // Initialize the score text with 0.
        UpdateScoreText();
    }

    // Function to update the score and score text.
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Function to update the score text.
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
