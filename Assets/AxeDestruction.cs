using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDestruction : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {

    if (other.transform.CompareTag("Killzone")) {
        Destroy(gameObject);
    }
  }
}
