using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparto_Cartas : MonoBehaviour
{
    private int[] reparto;
    private int[] contador,contador2;
    public GameObject[] cartas;
    void Start()
    {
        Reparto();
        Asignacion_num();
    }
    void Reparto() 
    {
        reparto = new int[10];
        contador = new int[5];
        contador2 = new int[5];
        int random,random2;
        for (int i = 0; i < 10; i++)
        {
            random = Random.Range(0, 5);//generamos numeros aleatorios del 0 al 4 para represantar los 5 tipos de cartas que hay
            random2 = Random.Range(0, 5);
            while ((random == 0 && contador[0] == 2) || (random == 1 && contador[1] == 2) || (random == 2 && contador[2] == 2) ||
                (random == 3 && contador[3] == 2) || (random == 4 && contador[4] == 2)) { random = Random.Range(0, 5); } //no aseguramos de que no se generen mas de
                                                                                                                         //2 veces el mismo numero
            contador[random]++; 
            reparto[i] = random;
        }
    }

    void Asignacion_num() 
    {
        for (int i = 0;i < cartas.Length; i++)
        {
            Cartas_Num cartaScript = cartas[i].GetComponent<Cartas_Num>();
            if (cartaScript != null)
            {
                cartaScript.numero = reparto[i]; // Asigna el número aleatorio
            }
        }
    }

}
