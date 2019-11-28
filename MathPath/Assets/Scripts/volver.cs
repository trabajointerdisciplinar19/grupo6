using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volver : MonoBehaviour
{
   void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("menu");
            
        }
    }
}
