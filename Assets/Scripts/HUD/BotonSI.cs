using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSI : MonoBehaviour
{
    public GameObject mensaje, pregunta; 

    private void OnMouseDown()
    {
        mensaje.SetActive(false);
        pregunta.SetActive(false);
        Time.timeScale = 1f;
    }
}
