using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClash : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other) {

    if ((other.transform.tag == "HeroProjectile") || other.transform.CompareTag("Killzone") || other.transform.CompareTag("HeroFinal") || other.transform.CompareTag("Player"))   {
        Destroy(gameObject);
    }
  }
}
