using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobster : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float speed = 3;
    //public Text scoreDisplay;
    //private int score = 0;
    private GameObject crab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate Crab
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
        crab = GameObject.Find("Crab");
    }

    // Update is called once per frame
    void Update()
    {
        // vänd mot crab
        Vector3 target = crab.transform.position - transform.position;
        float vinkel = Mathf.Atan2(target.y, target.x) * 180/Mathf.PI;
        rb.rotation = vinkel;
        float angleRadians = rb.rotation * Mathf.PI / 180f;
        float xSpeed = Mathf.Cos(angleRadians) * speed;
        float ySpeed = Mathf.Sin(angleRadians) * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Worm"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0);
        }
    }
}
