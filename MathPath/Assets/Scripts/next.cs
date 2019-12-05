using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{
    public GameObject dino;
    public GameObject nino;

    public GameObject elec01;
    public GameObject elec02;
    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            if (dino.activeSelf)
            {
                dino.SetActive(false);
                nino.SetActive(true);

                elec01.SetActive(false);
                elec02.SetActive(true);
            }
            else if (nino.activeSelf)
            {
                dino.SetActive(true);
                nino.SetActive(false);

                elec01.SetActive(true);
                elec02.SetActive(false);
            }
        }
    }
}
