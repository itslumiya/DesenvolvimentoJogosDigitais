using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (collision.CompareTag("Inimigo") && aliado)
        {
            Destroy(collision.gameObject);
            this.projetilInativo.Invoke();
            Destroy(this.gameObject);
            pontuacao = GameObject.FindWithTag("Pontuacao").GetComponent<UnityEngine.UI.Text>();
            int pontuacaoInt = int.Parse(pontuacao.text.ToString());
            pontuacaoInt += 10;
            pontuacao.text = pontuacaoInt.ToString();
        }
    }
}
