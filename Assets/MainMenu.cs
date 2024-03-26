using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Method to start the game
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace "SampleScene" with the name of your game scene
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
