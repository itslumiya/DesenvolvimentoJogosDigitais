using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class IAScript : MonoBehaviour
{
    public float boundYSup = 7.5f;
    public float boundYInf = 0;
    public float boundX = 5.8f;

    private Rigidbody2D rb;
    private Vector3 startingPosition;

    public 
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = GameObject.FindGameObjectWithTag("OpponentIA").transform.position;
}

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        Vector3 ballPos = GameObject.FindGameObjectWithTag("Disco").transform.position;
        if (ballPos.y >= 0) // Y >= 0 bola esta no meu campo
        {
            pos = Vector3.MoveTowards(transform.position, ballPos, 17.5f * Time.deltaTime);
        } else
        {
            pos = Vector3.MoveTowards(transform.position, startingPosition, 10 * Time.deltaTime);
        }

        if (pos.y > boundYSup)
        {
            pos.y = boundYSup;
        }
        else if (pos.y < boundYInf)
        {
            pos.y = boundYInf;
        }
        if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        transform.position = pos;

    }
}
