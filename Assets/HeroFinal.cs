using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFinal : MonoBehaviour
{
    public int scoreAmount = 20; // Amount of score to increase when hitting an enemy
    public float speed = 10f; // Speed of movement
    public float duration = 3f; // Duration before self-destruction
    private GameManager gameManager; // Reference to the GameManager


private void Start()
    {
        // Find the GameManager object and get its GameManager component
        gameManager = FindObjectOfType<GameManager>();

        StartCoroutine(SelfDestruct());
    }

    private void Update()
    {
        // Move the HeroFinal object on the X axis
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private IEnumerator SelfDestruct()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Destroy the HeroFinal object after the specified duration
        Destroy(gameObject);
    }
  private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Enemy"))
        {
            // Increase the score
            gameManager.IncreaseScore(scoreAmount);
        }
    }
}