using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    public TextMeshProUGUI minutero;
    public static float tiempoActual;
    public static int minutos, segundos;
    private void Update()
    {
        tiempoActual += Time.deltaTime;
        ActualizarReloj();
    }

    void ActualizarReloj()
    {
        minutos = Mathf.FloorToInt(tiempoActual / 60);//sacamos los minutos diviendo entre 60
        segundos = Mathf.FloorToInt(tiempoActual % 60);// y los segundos es el resto
        minutero.text = string.Format("{0:00}:{1:00}",minutos, segundos);
    }
}
