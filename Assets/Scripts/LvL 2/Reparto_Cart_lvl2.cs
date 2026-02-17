using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparto_Cart_lvl2 : MonoBehaviour
{
    private int[] reparto;
    private int[] contador;
    public GameObject[] cartas;
    void Start()
    {
        Reparto();
        Asignacion_num();
    }
    void Update()
    {

    }

    void Reparto()
    {
        reparto = new int[14];
        contador = new int[7];
        int random;
        for (int i = 0; i < 14; i++)
        {
            random = Random.Range(0, 7);//generamos numeros aleatorios del 0 al 6 para represantar los 7 tipos de cartas que hay
            while ((random == 0 && contador[0] == 2) || (random == 1 && contador[1] == 2) || (random == 2 && contador[2] == 2) ||
                (random == 3 && contador[3] == 2) || (random == 4 && contador[4] == 2) || (random == 5 && contador[5] == 2) 
                || (random == 6 && contador[6] == 2)) { random = Random.Range(0, 7); } // para asegurarse que no se generen mas de 2 veces el mismo numero

            contador[random]++;
            reparto[i] = random;
        }
    }

    void Asignacion_num()
    {
        for (int i = 0; i < cartas.Length; i++)
        {
            Cartas_Num cartaScript = cartas[i].GetComponent<Cartas_Num>();
            if (cartaScript != null)
            {
                cartaScript.numero = reparto[i]; // Asigna el número aleatorio
            }
        }
    }
}
