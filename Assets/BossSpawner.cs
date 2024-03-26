using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bossPrefabs;
    public float bossSpawnTime = 25f;
    public float bossSpeed = 1f;
    public float MoveStopX = 1f;

    private float timeUntilBossSpawn;
    private Dictionary<GameObject, float> initialYPositions = new Dictionary<GameObject, float>();

    private void Start()
    {
        // Start the initial boss spawn loop
        SpawnLoop();
    }

    private void Update()
    {
        // Only need to check for spawning if there are no bosses present
        if (GameObject.FindGameObjectWithTag("Boss") == null)
        {
            SpawnLoop();
        }
    }

    private void SpawnLoop()
    {
        timeUntilBossSpawn += Time.deltaTime;

        // Only spawn if the time threshold is met and no bosses are present
        if (timeUntilBossSpawn >= bossSpawnTime && GameObject.FindGameObjectWithTag("Boss") == null)
        {
            Spawn();
            timeUntilBossSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject bossToSpawn = bossPrefabs[Random.Range(0, bossPrefabs.Length)];
        GameObject spawnedBoss = Instantiate(bossToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D bossRB = spawnedBoss.GetComponent<Rigidbody2D>();

        // Set velocity to move towards the specified X coordinate
        bossRB.velocity = Vector2.left * bossSpeed;

        // Store initial Y position
        initialYPositions.Add(spawnedBoss, spawnedBoss.transform.position.y);

        // Start the coroutine to check for stopping movement
        StartCoroutine(CheckStopMovementCoroutine(spawnedBoss, bossRB));
    }

    private IEnumerator CheckStopMovementCoroutine(GameObject boss, Rigidbody2D bossRB)
    {
        while (boss != null && boss.transform.position.x >= MoveStopX)
        {
            yield return null;
        }

        // If boss still exists and reached or passed the stop X coordinate
        if (boss != null)
        {
            // Stop the movement
            bossRB.velocity = Vector2.zero;
        }
    }
}
