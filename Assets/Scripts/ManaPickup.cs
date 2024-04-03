using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    public int scoreAmount = 10; // Amount of score to increase when picked up
    public int manaAmount = 1;
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
            gameManager.CollectMana(manaAmount);

            // Destroy the Mana object
            Destroy(gameObject);
        }
    }
}
