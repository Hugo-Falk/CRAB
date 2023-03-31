using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Crab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
    public Text scoreDisplay;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate Crab
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
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
        }
        if (collision.gameObject.name.StartsWith("Lobster"))
        {
            // game over text
            // pause game
            // esc to restart
        }
    }
}