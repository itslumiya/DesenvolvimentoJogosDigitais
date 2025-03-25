using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    public float parallaxEffect;

    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * parallaxEffect;
        if (transform.position.x <= -lenght)
        {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }

    }
}
