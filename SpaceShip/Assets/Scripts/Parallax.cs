using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float parallaxEffect = 0.8f;
    private UnityEngine.UI.Text pontuacaoText;

    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * parallaxEffect;
        if (transform.position.x <= -lenght)
        {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }

        pontuacaoText = GameObject.FindWithTag("Pontuacao").GetComponent<UnityEngine.UI.Text>();
        int.TryParse(pontuacaoText.text, out int pontuacao);
        if (pontuacao % 40 == 0 && pontuacao > 0 && pontuacao != 120)
        {
            {
                slow();
            }
        }
        
        if(pontuacao == 330)
        {
            SceneManager.LoadScene("Vitoria");
        }
        
    }

    void slow()
    {
        parallaxEffect = 0.1f;
        Invoke("encerrarSlow", 1f);
    }

    void encerrarSlow()
    {
        parallaxEffect = 0.8f;
    }
}
