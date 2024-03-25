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
            Destroy(gameObject);
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
