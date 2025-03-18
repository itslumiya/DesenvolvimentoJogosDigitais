using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavesScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    public ProjetilScript projetil;
    private bool projetilEmCena;
    private float frequenciaAtaque;
    System.Random aleatorio = new System.Random();


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
        int valorAleatorio = aleatorio.Next(0 , 11);
        if(valorAleatorio < frequenciaAtaque)
        {
            Disparar();
        }


    }
    void ChangeState()
    {
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
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
