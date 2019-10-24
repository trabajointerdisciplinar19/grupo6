using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekGround : MonoBehaviour

    
{
    private playercontroller player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<playercontroller>();

        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        player.grounded = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        player.grounded = false;
    }
}
