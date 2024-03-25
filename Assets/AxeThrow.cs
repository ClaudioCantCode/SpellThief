using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    public GameObject axePrefab;
    public Transform axePos;
    public float shootInterval = 3f; // Interval between axe shots
    public int maxShots = 3; // Maximum number of shots allowed

    private int shotsFired = 0; // Counter to track shots fired
    private float timer;

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to shoot and maximum shots not reached
        if (timer >= shootInterval && shotsFired < maxShots)
        {
            // Reset timer
            timer = 0;

            // Shoot axe
            Shoot();

            // Increment shots fired
            shotsFired++;
        }
    }

    void Shoot()
    {
        Instantiate(axePrefab, axePos.position, Quaternion.identity);
    }
}
