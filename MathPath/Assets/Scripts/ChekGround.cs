using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ChekGround : MonoBehaviour 
{
    private playercontroller player;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<playercontroller>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0,0,0);
            player.transform.parent = collision.transform;
            player.grounded = true;
        }
    }
    //Busca en cada fotograma
    private void OnCollisionStay2D(Collision2D collision)
    {

        try
        {
            if (collision.gameObject.tag == "Ground")
            {
                player.grounded = true;
            }
            if (collision.gameObject.tag == "Platform")
            {
                player.transform.parent = collision.transform;
                player.grounded = true;
            }
        }
        catch (NullReferenceException e)
        {

        }
    }
  
    void OnCollisionExit2D(Collision2D collision)
    {
        try
        {
            if (collision != null && collision.gameObject.tag == "Ground")
            {
                player.grounded = false;
            }
            if (collision.gameObject.tag == "Platform")
            {
                player.transform.parent = null;
                player.grounded = false;
            }
        }
        catch(NullReferenceException e){ }
    }
}
