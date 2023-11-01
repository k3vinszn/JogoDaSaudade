using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI text displaying the score.
    private int score = 0; // The current score.

    // Function to increase the score.
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Function to update the score UI text.
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    // Function to handle game over and pass the score to the "Game Over" scene.
    public void GameOver()
    {
        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        
    }
}
