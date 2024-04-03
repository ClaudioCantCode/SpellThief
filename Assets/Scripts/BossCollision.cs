using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public GameObject lifePrefab; // Reference to the Mana prefab

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("HeroFinal")) {
            Debug.Log("Enemy destroyed by HeroFinal");
            SpawnLife(transform.position); // Spawn life at the enemy's position
            Destroy(gameObject); // Destroy the enemy
        }
    }

    private void SpawnLife(Vector3 spawnPosition)
    {
        // Instantiate a new Mana object at the given position
        GameObject manaObject = Instantiate(lifePrefab, spawnPosition, Quaternion.identity);
    }
}
