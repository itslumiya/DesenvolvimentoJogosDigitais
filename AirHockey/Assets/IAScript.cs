using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAScript : MonoBehaviour
{
    public float boundYSup = 0;
    public float boundYInf = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 opponentPos = GameObject.FindGameObjectWithTag("OpponentIA").transform.position;
        var pos = transform.position;
        pos.x = opponentPos.x;
        pos.y = opponentPos.y;

        Vector3 ballPos = GameObject.FindGameObjectWithTag("GoBall").transform.position;
        if (ballPos.y >= 0) // Y >= 0 bola esta no meu campo
        {

        }

        if (pos.y > boundYSup)
        {
            pos.y = boundYSup;
        }
        else if (pos.y < -boundYInf)
        {
            pos.y = -boundYInf;
        }
        transform.position = pos;
    }
}
