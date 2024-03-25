using UnityEngine;

public class HeroProjectileTouch : MonoBehaviour
{
    public int scoreAmount = 20; // Amount of score to increase when hitting an enemy

    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Find the GameManager object and get its GameManager component
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Enemy"))
        {
            // Increase the score
            gameManager.IncreaseScore(scoreAmount);

            // Destroy the projectile
            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("Projectile"))
        {
            // Destroy the projectile if it hits the ground or another projectile
            Destroy(gameObject);
        }
    }
}
