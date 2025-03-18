using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavesScript : MonoBehaviour
{
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    public ProjetilScript projetil;
    private bool projetilEmCena;
    int quantidade;
    private float frequenciaAtaque = 1.0f;
    GameObject[] listaInvasores;

    void Start()
    {
        InvokeRepeating(nameof(Disparar), this.frequenciaAtaque, this.frequenciaAtaque);
    }

    void Update()
    {
        listaInvasores = GameObject.FindGameObjectsWithTag("NaveInimiga");
        quantidade = listaInvasores.Length;
        Debug.Log(quantidade);
        if(quantidade == 0)
        {
            SceneManager.LoadScene("Vitoria");
        }
    }
    

    private void Disparar()
    {        
        foreach (GameObject invader in listaInvasores)
        {
            if (UnityEngine.Random.value < (1.0f/ (float)this.quantidade)) 
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
