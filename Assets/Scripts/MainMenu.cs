using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to handle Play Button click
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace "GameScene" with your actual game scene name
    }

    // Function to handle Quit Button click
    public void QuitGame()
    {
        Application.Quit(); // This will only work in a built application, not in the Unity editor
    }
}
