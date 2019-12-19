using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{

    public Image health;
    float hp, maxHP = 100f;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHP);
        health.transform.localScale = new Vector2(hp / maxHP, 1);
        if (hp == 0)
        {
            Application.LoadLevel("gameover");
        }
    }
}
