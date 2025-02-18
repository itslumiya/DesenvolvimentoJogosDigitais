using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    public float boundYSup = 0;
    public float boundYInf = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;

        if (pos.y > boundYSup) {                  
            pos.y = boundYSup;
        }
        else if (pos.y < -boundYInf) {
            pos.y = -boundYInf;
        }
        transform.position = pos;   
    }
}
