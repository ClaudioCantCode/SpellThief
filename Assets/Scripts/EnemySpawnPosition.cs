using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    public float spawnHeight = 0;

    // Start is called before the first frame update
    void Start()
    { 
      gameObject.transform.position = new Vector3(gameObject.transform.position.x , spawnHeight, gameObject.transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
