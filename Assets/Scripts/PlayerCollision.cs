using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }
 private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Enemy") || other.transform.CompareTag("Projectile"))
        {
            // Check if the player has an extra life
            if (gameManager != null && gameManager.life > 0)
            {
                // Consume an extra life
                gameManager.life--;
                if (gameManager.lifeText != null)
                {
                    gameManager.lifeText.text = "Extra Life: " + gameManager.life.ToString();
                }
                Debug.Log("Player consumed an extra life! Remaining lives: " + gameManager.life);

                // Player still alive, so no need to destroy it
                return;
            }

            // If player doesn't have an extra life or GameManager is missing, destroy the player
            Destroy(gameObject);

            // If GameManager reference is available, trigger game over
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            else
            {
                Debug.LogError("GameManager reference is missing!");
            }
        }
    }
}
