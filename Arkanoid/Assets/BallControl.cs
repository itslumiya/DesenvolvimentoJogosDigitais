using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private UnityEngine.UI.Text Score;
    private string GameMode;
    private int Lifes = 3;

    void Start()
    {
        GameMode = PlayerPrefs.GetString("GameMode");
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);

        var life1 = GameObject.FindWithTag("LifeCount1");
        var life2 = GameObject.FindWithTag("LifeCount2");
        var life3 = GameObject.FindWithTag("LifeCount3");

        if (GameMode == "Pacifico")
        {
            life1.gameObject.SetActive(false);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);
        }
        else
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
        }

    }

    void Update()
    {

    }

    void GoBall()
    {
        rb2d.AddForce(new Vector2(0, 50));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("BottomWall") && GameMode == "Pacifico")
        {
            Lifes--;

            if (Lifes == 2)
            {
                var life3 = GameObject.FindWithTag("LifeCount3");
                life3.gameObject.SetActive(false);
            }
            else if (Lifes == 1)
            {
                var life2 = GameObject.FindWithTag("LifeCount2");
                life2.gameObject.SetActive(false);
            }
            else if (Lifes == 0)
            {
                var life1 = GameObject.FindWithTag("LifeCount1");
                life1.gameObject.SetActive(false);
            }
            else
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                if (currentSceneName == "Fase 1")
                {
                    PlayerPrefs.SetInt("CurrentLevel", 1);
                }
                else if (currentSceneName == "Fase 2")
                {
                    PlayerPrefs.SetInt("CurrentLevel", 2);
                }
                else
                {
                    PlayerPrefs.SetInt("CurrentLevel", 3);
                }
                SceneManager.LoadScene("Derrota");
            }

            RestartGame();
        }

        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x + 2;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3) + 2;
            rb2d.velocity = vel;
        }

        if (coll.gameObject.tag == "Block")
        {
            int blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
            Destroy(coll.gameObject);
            blockCount--;
            Score = GameObject.FindWithTag("Score").GetComponent<UnityEngine.UI.Text>();
            int ScoreInt = int.Parse(Score.text.ToString());
            ScoreInt += 10;
            Score.text = ScoreInt.ToString();

            if (blockCount == 0)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;

                if (currentSceneName == "Fase 1")
                {
                    PlayerPrefs.SetInt("CurrentLevel", 1);
                    SceneManager.LoadScene("Vitoria");
                }
                else if (currentSceneName == "Fase 2")
                {
                    PlayerPrefs.SetInt("CurrentLevel", 2);
                    SceneManager.LoadScene("Vitoria");
                }
                else
                {
                    PlayerPrefs.SetInt("CurrentLevel", 3);
                    SceneManager.LoadScene("Fim");
                }

            }
        }

        if (coll.gameObject.tag == "SecureWalls")
        {
            RestartGame();
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0, -3.858532f);
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
