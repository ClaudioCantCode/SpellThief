using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Method to start the game
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace "YourGameSceneName" with the name of your game scene
    }
}
