using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            timer = 0;
            shoot();
        }
        void shoot()
        {
            Instantiate(arrow, arrowPos.position, Quaternion.identity);
        }
    }
}
