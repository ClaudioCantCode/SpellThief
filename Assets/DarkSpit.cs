using UnityEngine;

public class DarkSpit : MonoBehaviour
{
    public GameObject darknessPrefab;
    public Transform darkPos;
    public float shootInterval = 8f; // Interval between axe shots
    private float timer;

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to shoot and maximum shots not reached
        if (timer >= shootInterval)
        {
            // Reset timer
            timer = 0;

            // Shoot axe
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(darknessPrefab, darkPos.position, Quaternion.identity);
    }
}
