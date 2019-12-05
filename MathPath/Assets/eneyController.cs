using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneyController : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;
    private Rigidbody2D rb2d;
    private SpriteRenderer EnemyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        EnemyRenderer = GetComponent<SpriteRenderer>();
    }
   

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(Vector2.right * speed);

        float limiteSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limiteSpeed, rb2d.velocity.y);
        if(rb2d.velocity.x>-0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        if (speed < 0.0f)
        {
            EnemyRenderer.flipX = true;
        }
        else if (speed > 0.0f)
        {
            EnemyRenderer.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER____________");
        }
        
    }
}
