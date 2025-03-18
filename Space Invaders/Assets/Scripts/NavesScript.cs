using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class NavesScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    public ProjetilScript projetil;
    private bool projetilEmCena;
    int quantidade;
    private float frequenciaAtaque = 1.0f;
    List<GameObject> listaInvasores;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;

        projetilEmCena = false;

        
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

        listaInvasores = new List<GameObject>(GameObject.FindGameObjectsWithTag("NaveInimiga"));
        if(UnityEngine.Random.value < 0.02f)
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
        
        foreach(GameObject invader in listaInvasores)
        {
            if (UnityEngine.Random.value < 0.02f) 
            {               
                Instantiate(this.projetil, invader.transform.position, Quaternion.identity);
                break;
            }
        }       
    }

    private void ApagarProjetil()
    {
        projetilEmCena = false;
    }
}
