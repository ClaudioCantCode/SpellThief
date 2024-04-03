using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    // Constants for force increase
    public const float initialForce = 5f; // Initial force value
    private const float forceIncreaseAmount = 0.2f;
    private const float forceIncreaseInterval = 40f;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateProjectileDirection();

        // Set initial force
        force = initialForce;

        // Start coroutine to increase force over time
        StartCoroutine(IncreaseForceRoutine());
    }

    IEnumerator IncreaseForceRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(forceIncreaseInterval);
            force += forceIncreaseAmount;
            Debug.Log("Force increased! New force: " + force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                UpdateProjectileDirection();
            }
        }

        timer += Time.deltaTime;

        if (timer > 8)
        {
            Destroy(gameObject);
        }   
    }

    private void UpdateProjectileDirection()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = direction.normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);

            Debug.Log("Projectile direction updated: " + direction);
        }
    }
}
