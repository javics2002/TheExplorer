using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit2D 
{
    public class Creditos : MonoBehaviour
    {
        public Text Pto;
        public Text Comentario;
        static int final = 100;
        public AudioSource Gracias;

        void Start ()
        {
            if (PlayerCharacter.TengoPigmentoNegro == false || PlayerCharacter.TengoPigmentoRojo == false)
            {
                final = final - 10;
                Debug.Log("No tengo los 2 pigmentos: -10ptos");
            }
            if (Poste.Acerte == false)
            {
                final = final - 5;
                Debug.Log("No has leido el poste: -5ptos");
            }
            if (Dialogo.VengoFoto1 == true)
            {
                final = final - 15;
                Debug.Log("No has visto el primer abrigo: -15ptos");
            }
            if (Dialogo.VengoFoto2 == true)
            {
                final = final - 15;
                Debug.Log("No has visto el segundo abrigo: -15ptos");
            }
            final = final - Puntuacion.NumeroFallos;
            Debug.Log("Te has equivocado " + Puntuacion.NumeroFallos + " veces: -" + Puntuacion.NumeroFallos + "ptos");
            if(final <= 0)
            {
                final = 0;
            }
            Pto.text = final + "";
            if (final == 0)
            {
                Comentario.text = "¿En serio?";
            }
            else if (final < 70)
            {
                Comentario.text = "¿Lo has encontrado difícil? No te preocupes, lo importante es que no te has rendido.";
            }
            else if (final < 80)
            {
                Comentario.text = "Espero que hayas disfrutado del paisaje y que repitas la experiencia en el futuro.";
            }
            else if (final < 90)
            {
                Comentario.text = "Un trabajo excelente, ¡toma ya!";
            }
            else if (final < 100)
            {
                Comentario.text = "Madre mía, ¡qué grandes dotes para la exploración!";
            }
            else if (final == 100)
            {
                Comentario.text = "¡Wow! ¡Una exploración perfecta! ¡Tienes madera para esto! ¡Sigue así!";
            }
            Gracias.Play();
        }
    }
}