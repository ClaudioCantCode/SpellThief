using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public int scoreAmount = 100; // Amount of score to increase when picked up
    public int lifeAmount = 1;
    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Find the GameManager object and get its GameManager component
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the score
            gameManager.IncreaseScore(scoreAmount);
            
            // Collect mana
            gameManager.CollectLife(lifeAmount);

            // Destroy the Mana object
            Destroy(gameObject);
        }
    }
}
