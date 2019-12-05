using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    public GameObject dino;
    public GameObject nino;

    public GameObject elec01;
    public GameObject elec02;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elec01 = GameObject.FindGameObjectWithTag("elec01");
        elec02 = GameObject.FindGameObjectWithTag("elec02");

        if (elec01 == true)
        {
            dino.SetActive(true);
        }
        if (elec02 == true)
        {
            nino.SetActive(true);
        }

    }
}
