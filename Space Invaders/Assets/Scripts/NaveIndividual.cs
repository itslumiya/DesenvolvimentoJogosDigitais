using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveIndividual : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }
    }

    void ChangeState()
    {
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }
}
