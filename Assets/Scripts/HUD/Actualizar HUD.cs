using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActualizarHUD : MonoBehaviour
{
    private static int movimientos, puntos, movimientos2, puntos2;
    private static int minutos2, segundos2;
    public TextMeshProUGUI minutero,turno,puntuacion;
    void Start()
    {
        ActualizardorHUD();
    }
    void ActualizardorHUD()
    {
        movimientos = Levantar_Cartas_lvl2.movimientos2;
        puntos = Levantar_Cartas_lvl2.puntos2;//Cogemos los parametros de movimientos y puntos
        Turnos turno = FindObjectOfType<Turnos>();
        Puntuacion puntuacion = FindObjectOfType<Puntuacion>();
        if (movimientos == 0 &&  puntos == 0)
        {
            movimientos = Levantar_Cartas.movimientos;//los igualamos con los puntos y movimientos del lvl 1 para
            puntos = Levantar_Cartas.puntos;// que se mantengan entre los niveles
        }
        turno.turnos.text = movimientos.ToString();
        puntuacion.marcador.text = puntos.ToString();
    }


}
