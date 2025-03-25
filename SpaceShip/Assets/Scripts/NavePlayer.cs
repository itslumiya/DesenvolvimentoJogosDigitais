using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavePlayer : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public float speed = 5f;
    public float boundY = 5f;
    private Rigidbody2D rb2d;
    public ProjetilScript projetil;
    private bool projetilEmCena;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    async void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparar();
        }

        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
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
