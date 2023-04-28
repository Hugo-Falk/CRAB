using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Crab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
    public Text scoreDisplay;
    public Text gameover;
    public Text livDisplay;
    private int score = 0;
    private int liv = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate Crab
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
        gameover.enabled = false;

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))  // esc to restart
        {
            Debug.Log("ladda om scenen");
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene"); // ladda om scenen 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // walk
            float angleRadians = rb.rotation * Mathf.PI / 180f;
            float xSpeed = Mathf.Cos(angleRadians) * speed;
            float ySpeed = Mathf.Sin(angleRadians) * speed;
            rb.velocity = new Vector2(xSpeed, ySpeed);

            if (Input.GetKey(KeyCode.A))
            {
                // and turn left
                rb.rotation += Time.deltaTime * 180;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // and turn right
                rb.rotation -= Time.deltaTime * 180;
            }
        }
        else
        {
            // do not move
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.S))
        {
            float angleRadians = rb.rotation * Mathf.PI / 180f;
            float xSpeed = -Mathf.Cos(angleRadians) * speed;
            float ySpeed = -Mathf.Sin(angleRadians) * speed;
            rb.velocity = new Vector2(xSpeed, ySpeed);
            
            if (Input.GetKey(KeyCode.A))
            {
                // and turn left
                rb.rotation += Time.deltaTime * 180;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // and turn right
                rb.rotation -= Time.deltaTime * 180;
            }
        

    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Worm"))
        {
            Debug.Log(collision.gameObject.name);
            //Destroy(collision.gameObject);
            collision.gameObject.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0);
            score = score + 1;
            scoreDisplay.text = "Score: " + score;
            if (score == 50)
            {
                liv = liv + 1;
                livDisplay.text = "Liv: " + liv;
            }
        }

        if (collision.gameObject.name.StartsWith("Lobster"))
        {
            liv = liv - 1;
            livDisplay.text = "Liv: " + liv;
            collision.gameObject.transform.position = new Vector3(4.0f, 4.0f, 0.0f);
            if (liv == 0)
            {
                Time.timeScale = 0;  // pause game
                gameover.enabled = true;   // game over text
            }
        }
    }
}