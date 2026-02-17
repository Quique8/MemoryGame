using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boton_HUD : MonoBehaviour
{
    public float tamaño = 1.2f;
    private void OnMouseEnter()
    {
        gameObject.transform.localScale *= tamaño;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale /= tamaño;
    }
}
