using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola
    private float MaxVel = 20;
    public float boundY = 9;
    private UnityEngine.UI.Text ScoreSuperior;
    private UnityEngine.UI.Text ScoreInferior;
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    // Inicializa a bola randomicamente para esquerda ou direita
    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    // Start is called before the first frame update
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();  // Inicializa o objeto bola
        Invoke("GoBall", 2);                 // Chama a função GoBall após 2 segundos
        AudioSource = GameObject.FindWithTag("SaidaDeSom").GetComponent<AudioSource>();
    }

    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x + 5;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3) + 5;
            rb2d.velocity = vel;
            AudioSource.PlayOneShot(AudioClip);
        }
        else if (coll.collider.CompareTag("OpponentIA"))
        {
            Vector2 vel;
            vel.x = -rb2d.velocity.x + 5;
            vel.y = -((rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3) + 5);
            rb2d.velocity = vel;
            AudioSource.PlayOneShot(AudioClip);
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 4);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -9.1f)
        {
            ScoreSuperior = GameObject.FindWithTag("ScoreSuperior").GetComponent<UnityEngine.UI.Text>();
            int ScoreInt = int.Parse(ScoreSuperior.text.ToString());
            ScoreInt++;
            ScoreSuperior.text = ScoreInt.ToString();
            RestartGame();
        } 
        else if(transform.position.y > 9.1f)
        {
            ScoreInferior = GameObject.FindWithTag("ScoreInferior").GetComponent<UnityEngine.UI.Text>();
            int ScoreInt = int.Parse(ScoreInferior.text.ToString());
            ScoreInt++;
            ScoreInferior.text = ScoreInt.ToString();
            RestartGame();
        }
    }
}
