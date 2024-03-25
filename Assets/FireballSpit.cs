using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpit : MonoBehaviour
{
    public GameObject fireball;
    public Transform fireballPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4)
        {
            timer = 0;
            shoot();
        }
        void shoot()
        {
            Instantiate(fireball, fireballPos.position, Quaternion.identity);
        }
    }
}
