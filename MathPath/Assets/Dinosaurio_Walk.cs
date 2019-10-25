using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaurio_Walk : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D dinosaurio;
    public float maxvelocidad;
    bool voltearDinosaurio=true;
    SpriteRenderer DinoRenderer;
    Animator DinosaurioAnim;
    void Start()
    {
        dinosaurio = GetComponent<Rigidbody2D> ();
        DinoRenderer = GetComponent<SpriteRenderer> ();
        DinosaurioAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mover = Input.GetAxis("Horizontal");
        if(mover>0 && !voltearDinosaurio)
        {
            Voltear();
        }else if(mover<0 && voltearDinosaurio)
        {
            Voltear();
        }
        dinosaurio.velocity = new Vector2(mover * maxvelocidad, dinosaurio.velocity.y);
        DinosaurioAnim.SetFloat("Velocidad_movimiento", Mathf.Abs(mover));
    }
    void Voltear(){
        voltearDinosaurio = !voltearDinosaurio;
        DinoRenderer.flipX = !DinoRenderer.flipX;
    }
}
