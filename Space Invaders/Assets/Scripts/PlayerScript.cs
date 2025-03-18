using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerScript : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public float speed = 10.0f;
    public float boundX = 10.0f;
    private Rigidbody2D rb2d;
    public ProjetilScript projetil;
    private bool projetilEmCena;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    async void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparar();
        }




        rb2d.velocity = vel;

        var pos = transform.position;
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

    private void Disparar()
    {
        if (!projetilEmCena)
        {
            ProjetilScript projetilDisparado = Instantiate(this.projetil, this.transform.position, Quaternion.identity);
            projetilDisparado.projetilInativo += ApagarProjetil;
            projetilEmCena = true;
        }
    }

    private void ApagarProjetil()
    {
        projetilEmCena = false;
    }
}
