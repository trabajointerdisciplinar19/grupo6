using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{
    public GameObject dino;
    public GameObject nino;
    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            if (dino.activeSelf)
            {
                dino.SetActive(false);
                nino.SetActive(true);
            }
            else if (nino.activeSelf)
            {
                dino.SetActive(true);
                nino.SetActive(false);
            }
        }
    }
}
