using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekGround : MonoBehaviour

    
{
    private playercontroller player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<playercontroller>();

        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag=="Ground")
            player.grounded = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
            player.grounded = false;
    }
}
