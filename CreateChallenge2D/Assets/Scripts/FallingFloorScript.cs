using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorScript : MonoBehaviour
{
    public float timeForFall;
    bool fall;
    Rigidbody2D rb;
    public int fallSpeed;

    private void Start()
    {
        fall = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fall = true;
        }
    }

    private void Update()
    {
        if (fall)
        {
            timeForFall -= Time.deltaTime;
            if(timeForFall <= 0)
            {
                rb.gravityScale = fallSpeed;
            }
        }
    }
}
