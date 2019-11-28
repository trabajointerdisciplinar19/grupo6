using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaurio_Walk : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D dinosaurio;
    public float maxvelocidad;
    Animator DinosaurioAnim;
    bool puedeMover = true;

    //saltar
    bool EnSuelo = false;
    float CheakRadioSuelo = 0.2f;
    public LayerMask capaSuelo;
    public Transform chequearSuelo;
    public float poderSalto;

    bool voltearDinosaurio = true;
    SpriteRenderer DinoRenderer;
    void Start()
    {
        dinosaurio = GetComponent<Rigidbody2D> ();
        DinoRenderer = GetComponent<SpriteRenderer> ();
        DinosaurioAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puedeMover && EnSuelo && Input.GetAxis("Jump") > 0)
        {
            DinosaurioAnim.SetBool("EstaSuelo", false);
            dinosaurio.velocity = new Vector2(dinosaurio.velocity.x, 0f);
            dinosaurio.AddForce(new Vector2(0, poderSalto), ForceMode2D.Impulse);
            EnSuelo = false;
        }
        EnSuelo = Physics2D.OverlapCircle(chequearSuelo.position, CheakRadioSuelo, capaSuelo);
        DinosaurioAnim.SetBool("EstaSuelo", EnSuelo);
        float mover = Input.GetAxis("Horizontal");
        if (puedeMover)
        {
            if (mover > 0 && !voltearDinosaurio)
            {
                Voltear();
            }
            else if (mover < 0 && voltearDinosaurio)
            {
                Voltear();
            }
            dinosaurio.velocity = new Vector2(mover * maxvelocidad, dinosaurio.velocity.y);
            DinosaurioAnim.SetFloat("Velocidad_movimiento", Mathf.Abs(mover));
        } else
        {
            dinosaurio.velocity = new Vector2(0, dinosaurio.velocity.y);
            DinosaurioAnim.SetFloat("Velocidad_movimiento", 0);
        }
    }
    void Voltear(){
        voltearDinosaurio = !voltearDinosaurio;
        DinoRenderer.flipX = !DinoRenderer.flipX;
    }
    public void togglePuedeMover()
    {
        puedeMover = !puedeMover;
    }
}
