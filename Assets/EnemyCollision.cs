using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject manaPrefab; // Reference to the Mana prefab

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("HeroProjectile") || other.transform.CompareTag("Killzone") || other.transform.CompareTag("HeroFinal")) {
            Debug.Log("Enemy destroyed by HeroProjectile");
            SpawnMana(transform.position); // Spawn Mana at the enemy's position
            Destroy(gameObject); // Destroy the enemy
        }
    }

    private void SpawnMana(Vector3 spawnPosition)
    {
        // Instantiate a new Mana object at the given position
        GameObject manaObject = Instantiate(manaPrefab, spawnPosition, Quaternion.identity);
    }
}
