using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float timer;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 16)
        {
            Destroy(gameObject);
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            UpdateProjectileDirection();
        }
    }

    private void UpdateProjectileDirection()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = direction.normalized * force;

            float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);

            Debug.Log("Projectile direction updated: " + direction);
        }
    }
}
