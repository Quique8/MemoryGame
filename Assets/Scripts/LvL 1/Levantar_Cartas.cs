using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Levantar_Cartas : MonoBehaviour
{
    public static int puntos,movimientos;
    public GameObject carta0;
    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    private Anim_Mazo Anim_Mazo;
    public static int contador = 0, numcarta1, numcarta2, aciertos;
    public static GameObject cartaLevantada1, cartaLevantada2;
    private static GameObject cartaDetras1, cartaDetras2;
    public GameObject mensaje,pregunta;
    public Vector3 defaultscale;


    void Start()
    {
        Anim_Mazo = FindObjectOfType<Anim_Mazo>();
        Actualizar_HUD();
    }
    private void Update()
    {
        Pause();
    }

    void OnMouseDown()
    {
        if (Anim_Mazo.isAnimationFinished && contador < 2)//nos aseguramos de que la animacion de repartir haya acabado
        {
            Turnos turno = FindObjectOfType<Turnos>();
            Animator animator = GetComponent<Animator>();
            Cartas_Num cartas_Num = GetComponent<Cartas_Num>();
            int num = cartas_Num.numero;
            Vector2 position = transform.position;
            GameObject cartaInstanciada = null;
            gameObject.SetActive(false); // Desactiva la carta detrás

            // Instanciamos la carta según el número que tenga
            switch (num)
            {
                case 0: cartaInstanciada = Instantiate(carta0, position, Quaternion.identity); contador++; break;
                case 1: cartaInstanciada = Instantiate(carta1, position, Quaternion.identity); contador++; break;
                case 2: cartaInstanciada = Instantiate(carta2, position, Quaternion.identity); contador++; break;
                case 3: cartaInstanciada = Instantiate(carta3, position, Quaternion.identity); contador++; break;
                case 4: cartaInstanciada = Instantiate(carta4, position, Quaternion.identity); contador++; break;
                default: return;
            }

            movimientos++;
            turno.turnos.text = movimientos.ToString();

            if (contador == 1)
            {
                cartaLevantada1 = cartaInstanciada;
                numcarta1 = num;
                cartaDetras1 = gameObject; // Guarda la referencia a la primera carta detrás
            }
            else if (contador == 2)
            {
                cartaLevantada2 = cartaInstanciada;
                numcarta2 = num;
                cartaDetras2 = gameObject; // Guarda la referencia a la segunda carta detrás
                Invoke("VerificarCartas", 1f);
            }
        }
    }

    void VerificarCartas()
    {
        Puntuacion puntuacion = FindObjectOfType<Puntuacion>();
        if (numcarta1 == numcarta2)
        {
            //si son iguales destruimos las cartas y añadimos los puntos al jugador
            Destroy(cartaLevantada1); 
            Destroy(cartaLevantada2);
            puntos += 100;
            puntuacion.marcador.text = puntos.ToString("0");
            aciertos++;
        }
        else
        {
            //si son diferentes destruimos las cartas levantadas y volvemos a activar las cartas detras, tambien retiramos
            //los puntos al jugador por el error
            Destroy(cartaLevantada1); 
            Destroy(cartaLevantada2); 
            cartaDetras1.SetActive(true);
            cartaDetras2.SetActive(true);
            if(puntos >= 50)
            {
                puntos -= 50;
                puntuacion.marcador.text = puntos.ToString();
            }
        }
        Invoke("ResetStats", 0.5f);
        if (aciertos == 5)
        {
            Invoke("Pregunta",0.5f);
            Invoke("Juego",1f);
        }
    }

    public void ResetStats()
    {
        contador = 0;
        cartaLevantada1 = null;
        cartaLevantada2 = null;
        cartaDetras1 = null;
        cartaDetras2 = null;
    }
    

    void Juego()
    {
        if(puntos >= 500)//si supera los puntos se carga el lvl2 si no vuelve a empezar el lvl1
        {
            SceneManager.LoadScene("nivel 2");
        }
        else
        {
            SceneManager.LoadScene("Nivel 1");
        }
        aciertos = 0;
    }

    void Actualizar_HUD()
    {
        //Actualizamos el HUD al cargar la escena
        Turnos turno = FindObjectOfType<Turnos>();
        Puntuacion puntuacion = FindObjectOfType<Puntuacion>();
        turno.turnos.text = movimientos.ToString();
        puntuacion.marcador.text = puntos.ToString();
    }

    void Pregunta()
    {
        //preguntamos al jugador si quiere seguir jugando
        pregunta.SetActive(true);
        mensaje.SetActive(true);
        defaultscale = new Vector3(0.2830916f, 0.2830916f, 0.2830916f);
        BotonSI BotonSI = FindObjectOfType<BotonSI>();
        BotonSI.gameObject.transform.localScale = defaultscale;
        Time.timeScale = 0;
    }

    void Pause()
    {
        //al presionar una tecla invoca la funcion de Pregunta a modo de pausa 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pregunta();
        }
    }
}








