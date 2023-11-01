using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text scoreText;


    void Start()
    {
       
    }


    // Function to handle Play Button click
    public void Retry()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with your actual game scene name
    }

    public void MainMeny()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "GameScene" with your actual game scene name
    }
    // Function to handle Quit Button click
    public void QuitGame()
    {
        Application.Quit(); // This will only work in a built application, not in the Unity editor
    }

}
