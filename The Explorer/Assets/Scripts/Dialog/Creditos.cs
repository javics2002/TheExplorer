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
			GameManager.Instance.fmodEvents.PlayDialogue("Resultado");

            ResetGame();
		}

        public void StopDialogue() {
            GameManager.Instance.fmodEvents.StopDialogue();
        }

        void ResetGame() {
            Debug.Log("Juego reseteado");

            PlayerCharacter.PuedoMoverme = true;
			PlayerCharacter.TengoPigmentoRojo = false;
			PlayerCharacter.TengoPigmentoNegro = false;
			PlayerCharacter.TengoGafas = false;
			PlayerCharacter.TengoPalos = false;
			PlayerCharacter.TengoTubo = false;
			PlayerCharacter.TengoResina = false;
			PlayerCharacter.TengoPicos = false;
			PlayerCharacter.UsoPicos = false;

            Puerta.CualDigo = 1;
            Puerta.TransitionPointActivo = false;

            ActivateData.Data1 = false;
            ActivateData.Data2 = false;
            ActivateData.Data3 = false;
            ActivateData.Data4 = false;
            ActivateData.Data5 = false;

            Poste.Acerte = false;

			Dialogo.Dialogo0 = true;
			Dialogo.Dialogo1 = true;
			Dialogo.Dialogo2 = false;
			Dialogo.Dialogo3 = true;
			Dialogo.Dialogo4 = true;
			Dialogo.Dialogo5 = false;
			Dialogo.Dialogo6 = true;
			Dialogo.Dialogo7 = false;
			Dialogo.Dialogo8 = true;
			Dialogo.Dialogo9 = true;
			Dialogo.Dialogo10 = false;
			Dialogo.Dialogo11 = false;
			Dialogo.Dialogo12 = false;
			Dialogo.Dialogo13 = false;
			Dialogo.Dialogo14 = false;
			Dialogo.Dialogo15 = true;
			Dialogo.Dialogo16 = false;
			Dialogo.Dialogo17 = false;
			Dialogo.PicosB = false;
			Dialogo.Pregunta1 = true;
			Dialogo.Pregunta2 = true;
			Dialogo.Pregunta3 = true;
			Dialogo.Pregunta4 = true;
			Dialogo.Pregunta5 = true;
			Dialogo.Pregunta6 = true;
			Dialogo.HeConstruidoelTelescopio = false;
            Dialogo.PrimeraVez = true;
			Dialogo.VengoFoto1 = true;
			Dialogo.VengoFoto2 = true;
            Dialogo.NumberD = 100;

            Puntuacion.NumeroFallos = 0;
            SinPicos.texto = false;

            PersistentDataManager.ClearPersisters();
		}
    }
}