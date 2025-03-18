using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class ProjetilScript : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action projetilInativo;
    public bool aliado;
    private UnityEngine.UI.Text pontuacao;
    private int vidas = 3;

    void Start()
    {
        
    }

    void Update()
    {
        
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !aliado)
        {
            vidas--;
            if (vidas == 2)
            {
                var life3 = GameObject.FindWithTag("Vida3");
                life3.gameObject.SetActive(false);

            }
            else if (vidas == 1)
            {
                var life2 = GameObject.FindWithTag("Vida2");
                life2.gameObject.SetActive(false);
            }
            else if (vidas == 0)
            {
                var life1 = GameObject.FindWithTag("Vida1");
                life1.gameObject.SetActive(false);
                SceneManager.LoadScene("Derrota");

            }
            this.projetilInativo.Invoke();
            Destroy(this.gameObject);
        }
        else if(collision.CompareTag("NaveInimiga") && aliado)
        {
            Destroy(collision.gameObject);
            this.projetilInativo.Invoke();
            Destroy(this.gameObject);
            pontuacao = GameObject.FindWithTag("Pontuacao").GetComponent<UnityEngine.UI.Text>();
            int pontuacaoInt = int.Parse(pontuacao.text.ToString());
            pontuacaoInt += 10;
            pontuacao.text = pontuacaoInt.ToString();
        }
        else if(collision.CompareTag("Limite") || (collision.CompareTag("Barreira") && aliado))
        {
            this.projetilInativo.Invoke();
            Destroy(this.gameObject);
        }
    }
}
