using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    public float enemySpawnTime = 2f;
    public float enemySpeed = 1f;
    public float flyStartX = -3.5f; // X-coordinate where MonsterFly and MonsterSniper start flying
    public float flyHeight = -6f; // Y-coordinate to fly to
    public float flySpeed = 5f; // Speed at which MonsterFly and MonsterSniper fly

    private float timeUntilEnemySpawn;
    private Dictionary<GameObject, float> initialYPositions = new Dictionary<GameObject, float>();

    private void Update()
    {
        SpawnLoop();
        MoveFlyingEnemies();
    }

    private void SpawnLoop()
    {
        timeUntilEnemySpawn += Time.deltaTime;

        if (timeUntilEnemySpawn >= enemySpawnTime)
        {
            Spawn();
            timeUntilEnemySpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D enemyRB = spawnedEnemy.GetComponent<Rigidbody2D>();
        enemyRB.velocity = Vector2.left * enemySpeed;

        // Store initial Y position
        initialYPositions.Add(spawnedEnemy, spawnedEnemy.transform.position.y);
    }

    private void MoveFlyingEnemies()
    {
        // Move MonsterFly and MonsterSniper enemies when they reach flyStartX
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy.GetComponent<MonsterFly>() != null || enemy.GetComponent<MonsterSniper>() != null)
            {
                Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();
                if (enemy.transform.position.x <= flyStartX)
                {
                    // Fly upwards to flyHeight
                    float initialY = initialYPositions[enemy];
                    Vector3 targetPosition = new Vector3(enemy.transform.position.x, flyHeight, enemy.transform.position.z);
                    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, flySpeed * Time.deltaTime);
                }
            }
        }
    }
    private IEnumerator IncreaseEnemySpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(25f);
            enemySpeed += 0.3f; // Increase enemy speed
            Debug.Log("Enemy speed increased! New speed: " + enemySpeed);
        }
    }
}
