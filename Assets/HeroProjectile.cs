using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectile : MonoBehaviour
{
    private Transform target; // Target enemy to follow
    public float speed = 5f; // Projectile speed
    public float lifetime = 8f; // Lifetime of the projectile in seconds
    public float searchRadius = 10f; // Radius within which to search for new targets

    // Method to set the target enemy
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Start()
    {
        // Start the coroutine to destroy the projectile after its lifetime
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate direction towards the target
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Move towards the target
            transform.Translate(direction * speed * Time.deltaTime);

            // Rotate towards the target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            // If the target is null, search for a new target
            SearchForNewTarget();
        }
    }

    IEnumerator DestroyAfterLifetime()
    {
        // Wait for the specified lifetime duration
        yield return new WaitForSeconds(lifetime);

        // Destroy the projectile GameObject
        Destroy(gameObject);
    }

    void SearchForNewTarget()
    {
        // Find all enemies within the search radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius);
        float closestDistance = Mathf.Infinity;
        Transform newTarget = null;

        // Iterate through the colliders to find the closest enemy
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    newTarget = collider.transform;
                }
            }
        }

        // Set the new target if one is found
        if (newTarget != null)
        {
            target = newTarget;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the search radius in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}
