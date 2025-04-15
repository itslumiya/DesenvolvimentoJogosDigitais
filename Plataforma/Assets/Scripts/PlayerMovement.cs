using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb2d;
    [SerializeField] private int velocity = 5;
    [SerializeField] private Transform characterFoot;
    [SerializeField] private LayerMask groundLayer;

    private bool inTheGround;
    private Animator animator;
    private int movingHash = Animator.StringToHash("Moving");
    private int jumpingHash = Animator.StringToHash("Jumping");
    private SpriteRenderer spriteRenderer;
    private int lifes = 3;
    private int points = 0;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && inTheGround){
            rb2d.AddForce(Vector2.up * 600);
        }

        inTheGround = Physics2D.OverlapCircle(characterFoot.position, 0.2f, groundLayer);

        animator.SetBool(movingHash, horizontalInput != 0);
        animator.SetBool(jumpingHash, !inTheGround);

        if(horizontalInput > 0){
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0){
            spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalInput * velocity, rb2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("FallZone"))
        {
            DecrementLifes();
            transform.position = new Vector2(-7.38f, 0.21f);
        } else if(coll.CompareTag("Cherry"))
        {
            Destroy(coll.gameObject);
            points++;
            GameObject countObject = GameObject.FindGameObjectWithTag("Count");
            Text count = countObject.GetComponent<Text>();
            count.text= points.ToString("D3");

            GameObject[] cherries = GameObject.FindGameObjectsWithTag("Cherry");
            int cherriesLeft = cherries.Length;

            if(cherriesLeft == 1){
                SceneManager.LoadScene("YouWin");
            }
        } else if (coll.CompareTag("Enemy")){
            if (transform.position.y > coll.transform.position.y)
            {
                Destroy(coll.gameObject);
                rb2d.AddForce(Vector2.up * 600);
            }
            else
            {
                DecrementLifes();
            }
        }
    }

    void DecrementLifes()
    {
        if(lifes == 0){
            PlayerPrefs.SetString("LevelAtual", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("GameOver");
        } else if(lifes == 3){
            GameObject life3 = GameObject.FindWithTag("Life3");
            Destroy(life3);
        } else if (lifes == 2){
            GameObject life2 = GameObject.FindWithTag("Life2");
            Destroy(life2);
        } else if (lifes == 1){
            GameObject life1 = GameObject.FindWithTag("Life1");
            Destroy(life1);
        }
        lifes--;
    }
}
