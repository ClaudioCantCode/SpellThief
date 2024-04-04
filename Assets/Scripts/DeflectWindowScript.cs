using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectWindowScript : MonoBehaviour
{
    private List<GameObject> Projectiles = new List<GameObject>();
    public GameObject heroProjectilePrefab; // Reference to the HeroProjectile prefab
    public GameObject heroFinalPrefab; // Reference to the HeroFinal prefab

    private bool canDeflect = true; // Flag to track if the deflect action is available
    public float deflectCooldown = 1f; // Cooldown duration in seconds
    public float visibilityDuration = 1f;

    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Find the GameManager object and get its GameManager component
        gameManager = FindObjectOfType<GameManager>();

        StartCoroutine(DecreaseDeflectCooldown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            // Add the enemy projectile to the list
            Projectiles.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            // Remove the enemy projectile from the list
            Projectiles.Remove(collision.gameObject);
        }
    }

    void Update()
    {
        // Check if the deflect action can be performed and the LeftShift key is pressed
        if (canDeflect && Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Perform deflection action
            PerformDeflectionAction();
        }

        // Check if the player can shoot and the shoot button is pressed
       if (Input.GetKeyDown(KeyCode.RightShift))
    {
        // Check if mana is 10 or more to prioritize shooting HeroFinal
        if (gameManager.mana >= 10)
        {
            // Perform shooting action for HeroFinal
            ShootFinal();
        }
        else
        {
            // Perform shooting action for HeroProjectile
            Shoot();
        }
    }
    }

    private void PerformDeflectionAction()
    {

         // Toggle transparency of objects tagged as "Player"
        ToggleObjectTransparency("Player", true);
        // Toggle visibility of objects tagged as "ParryAnim"
        ToggleObjectVisibility("ParryAnim", true);

        // Disable deflect action and start cooldown
        canDeflect = false;
        StartCoroutine(StartCooldown());

        // Perform deflection action for each projectile
        foreach (GameObject projectile in Projectiles.ToArray())
        {
            // Destroy the existing enemy projectile
            Destroy(projectile);

            // Replace with new HeroProjectile
            SpawnNewHeroProjectile(projectile.transform.position);
        }

        // Clear the list of enemy projectiles
        Projectiles.Clear();

       StartCoroutine(RevertVisibility());
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(deflectCooldown);
        canDeflect = true; // Enable deflect action after cooldown
    }

    private IEnumerator RevertVisibility()
    {
        yield return new WaitForSeconds(visibilityDuration);

        // Revert transparency of objects tagged as "Player"
        ToggleObjectTransparency("Player", false);
        // Revert visibility of objects tagged as "ParryAnim"
        ToggleObjectVisibility("ParryAnim", false);
    }

    private void ToggleObjectTransparency(string tag, bool transparent)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (transparent)
                {
                    Color color = renderer.material.color;
                    color.a = 0.5f; // Set transparency to 50%
                    renderer.material.color = color;
                }
                else
                {
                    Color color = renderer.material.color;
                    color.a = 1f; // Set transparency to 100%
                    renderer.material.color = color;
                }
            }
        }

    }

         private void ToggleObjectVisibility(string tag, bool visible)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = visible;
            }
        }
    }

    private void Shoot()
{
    // Check if mana is 3 or more to shoot HeroProjectile
    if (gameManager.mana >= 3)
    {
        // Spawn HeroProjectile
        SpawnNewHeroProjectile(transform.position);
        Debug.Log("Shoot Function");

        // Consume mana
        gameManager.ConsumeMana(3); // Consume 3 mana for shooting HeroProjectile
    }
}

    private void ShootFinal()
{
    // Spawn HeroFinal
    SpawnNewHeroFinal(transform.position);
    Debug.Log("Shoot Final Function");

    // Consume mana
    gameManager.ConsumeMana(10); // Consume 10 mana for shooting HeroFinal
}

    private void SpawnNewHeroProjectile(Vector3 spawnPosition)
    {
        // Instantiate a new HeroProjectile at the given position
        GameObject newProjectile = Instantiate(heroProjectilePrefab, spawnPosition, Quaternion.identity);

        // Find the closest enemy and make the HeroProjectile follow it
        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            newProjectile.GetComponent<HeroProjectile>().SetTarget(closestEnemy.transform);
        }
    }

    private void SpawnNewHeroFinal(Vector3 spawnPosition)
    {
        // Instantiate a new HeroFinal at the given position
        Instantiate(heroFinalPrefab, spawnPosition, Quaternion.identity);
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

       private IEnumerator DecreaseDeflectCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(40f);
            deflectCooldown = Mathf.Max(0.2f, deflectCooldown - 0.1f); // Clamp the cooldown to a minimum of 0.2 seconds
            Debug.Log("Deflect cooldown reduced! New cooldown: " + deflectCooldown);
        }
    }
}

