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
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        Debug.Log("increase score");
    }

    // Function to update the score UI text.
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
        
    }


}
