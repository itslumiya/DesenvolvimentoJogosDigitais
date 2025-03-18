using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class NavesScript : MonoBehaviour
{
    
    
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    public ProjetilScript projetil;
    private bool projetilEmCena;
    int quantidade;
    private float frequenciaAtaque = 1.0f;
    GameObject[] listaInvasores;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Disparar), this.frequenciaAtaque, this.frequenciaAtaque);
    }

    // Update is called once per frame
    void Update()
    {

        listaInvasores = GameObject.FindGameObjectsWithTag("NaveInimiga");
        quantidade = listaInvasores.Length;
    }
    

    private void Disparar()
    {
        Debug.Log("Chamou a func");
        
        foreach (GameObject invader in listaInvasores)
        {
            Debug.Log("Verificou invasor");
            if (UnityEngine.Random.value < (1.0f/ (float)this.quantidade)) 
            {
                Debug.Log("Disparo");
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
