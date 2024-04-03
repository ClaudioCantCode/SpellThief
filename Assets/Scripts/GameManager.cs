using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int score = 0; // Variable to store the score
    public int mana = 0; // Variable to store the mana

    public int life = 0;
    public TextMeshProUGUI scoreText; // Reference to the UI Text element
    public TextMeshProUGUI manaText; // Reference to the UI Text element for mana

    public TextMeshProUGUI lifeText;

   private Coroutine scoreCoroutine; // Coroutine reference to track the score increase

    void Start()
    {
        // Start the coroutine to increase score every second
        scoreCoroutine = StartCoroutine(IncreaseScoreRoutine());
    }

    IEnumerator IncreaseScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            IncreaseScore(1); // Increase score by 1
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // Increment the score by the specified amount
        Debug.Log("Score increased! Current score: " + score);
        
        // Update the UI Text element with the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
    public void CollectLife(int amount)
    {
        life += amount; // Increment lives by the specified amount
        Debug.Log("Life increased! Current life: " + life);
        
        // Update the UI Text element with the current score
        if (lifeText != null)
        {
            lifeText.text = "Extra Life: " + life.ToString();
        }
    }

    public void CollectMana(int amount)
    {
        mana += amount; // Increment the mana by the specified amount
        Debug.Log("Mana collected! Current mana: " + mana);
        
        // Update the UI Text element with the current mana
        if (manaText != null)
        {
            manaText.text = "Mana: " + mana.ToString();
        }
    }

    public void ConsumeMana(int amount)
    {
        if (mana >= amount)
        {
            mana -= amount; // Decrease the mana by the specified amount
            Debug.Log("Mana consumed! Current mana: " + mana);
            
            // Update the UI Text element with the current mana
            if (manaText != null)
            {
                manaText.text = "Mana: " + mana.ToString();
            }
        }
        else
        {
            Debug.Log("Not enough mana to consume!");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Add your game over logic here, like displaying a game over screen, resetting the level, etc.
        ResetLevel();
    }

    public void ResetLevel()
    {
        // Reset the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
