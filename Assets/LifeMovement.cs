using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMovement : MonoBehaviour
{
    public float speed = 2f; // Speed at which Mana moves

    void FixedUpdate()
    {
        // Move the Mana object in the negative X direction
        Vector3 movement = Vector3.left * speed * Time.fixedDeltaTime;
        transform.position += movement;
    }
}
