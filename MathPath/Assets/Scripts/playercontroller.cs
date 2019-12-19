using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;
    public bool isJump;
    public bool doubleJump;
    private float temp;
    private bool movement = true;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer PlayerRenderer;
    void Start()
    {
        temp = jumpPower;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        
        anim.SetBool("Grounded", grounded);
        if (Input.GetKeyDown(KeyCode.UpArrow)&&grounded){

            isJump = true;
            doubleJump = true;
        }
    }

    void FixedUpdate(){
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity *= 0.75f;
        
        if (grounded){
            rb2d.velocity = fixedVelocity;
        }
        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;
        rb2d.AddForce(Vector2.right * speed * h);

        float limiteSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limiteSpeed, rb2d.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (h <0.0f){
            PlayerRenderer.flipX = true;
        }
        else if (h >0.0f){
            PlayerRenderer.flipX = false;
        }

        if (isJump){
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            isJump = false;
        }
        jumpPower = temp;
    }
    public void EnemyJump()
    {
        
        jumpPower *= 0.5f;
        isJump= true;
    }
    public void EnemyKnockBack(float enemyPosX)
    {
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        isJump = true;
        rb2d.AddForce(Vector2.left * side * jumpPower * 0.5f, ForceMode2D.Impulse);
        movement = false;
        Invoke("EnableMovement", 0.7f);
        PlayerRenderer.color = Color.red;
    }
    private void OnBecameInvisible(){
        transform.position = new Vector3(0, 0, 0);
    }
    void EnableMovement()
    {
        movement = true;
        PlayerRenderer.color = Color.white;
    }
}
