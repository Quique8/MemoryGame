using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonEntrar : MonoBehaviour
{
    private void OnMouseDown()
    {
        //reseteamos las estadisticas al iniciar cada partida
        SceneManager.LoadScene("Nivel 1");
        Levantar_Cartas.puntos = 0;
        Levantar_Cartas.movimientos = 0;
        Levantar_Cartas.contador = 0;
        Levantar_Cartas.aciertos = 0;
        Levantar_Cartas_lvl2.puntos2 = 0;
        Levantar_Cartas_lvl2.movimientos2 = 0;
        Levantar_Cartas_lvl2.contador = 0;
        Levantar_Cartas_lvl2.aciertos = 0;
        Reloj.tiempoActual = 0;
        Time.timeScale = 1f;
    }
}
