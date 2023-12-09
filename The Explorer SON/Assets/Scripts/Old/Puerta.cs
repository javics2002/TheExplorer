using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Puerta : MonoBehaviour
    {
        public DialogueCanvasController DialogueCanvasController;
        public TransitionPoint TransitionPoint;
        public static bool TransitionPointActivo = false;
        public string Temprano; //1
        public string MeFaltaResina; //2
        public string YaPuedo; //3
        public static int CualDigo = 1;
        float DelayTime;
        public float Delay1 = 8;
        public float Delay2 = 12;
        public float Delay3 = 9;
        bool Active = false;
        public BoxCollider2D Puert;
        public SpriteRenderer abierto;
        public SpriteRenderer cerrado;

        void OnTriggerStay2D ()
        {
            abierto.enabled = true;
            cerrado.enabled = false;

            if(Input.GetButtonDown("Interact") && TransitionPointActivo == false)
            {
                Dialogo.NumberD = 100;

                if(CualDigo == 1)
                {
                    DialogueCanvasController.ActivateCanvasWithText(Temprano);
					GameManager.Instance.fmodEvents.PlayDialogue("AunNo");
					DelayTime = Delay1;
                }

                else if(CualDigo == 2)
                {
                    DialogueCanvasController.ActivateCanvasWithText(MeFaltaResina);
					GameManager.Instance.fmodEvents.PlayDialogue("FaltaAlgo");
					DelayTime = Delay2;
                }

                else if(CualDigo == 3)
                {
                    DialogueCanvasController.ActivateCanvasWithText(YaPuedo);
					GameManager.Instance.fmodEvents.PlayDialogue("Termino");
					DelayTime = Delay3;
                } 

                Active = true;
                PlayerCharacter.PuedoMoverme = false;
            }
        }

        void OnTriggerExit2D ()
        {
            abierto.enabled = false;
            cerrado.enabled = true;
        }

        void Start ()
        {
            if(TransitionPointActivo == true)
            {
                TransitionPoint.enabled = true;
                Puert.enabled = false;
            }
            else
            {
                TransitionPoint.enabled = false;
                Puert.enabled = true;
            }
        }

        void Update ()
        {
			if (Input.GetButtonDown("Interact") && Active == true)
            {
                PlayerCharacter.PuedoMoverme = true;
                DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime);
                Active = false;
                if(CualDigo == 3)
                {
                    Invoke("ActivaTransitionPoint", DelayTime);
					Puert.enabled = false;
					PlayerCharacter.PuedoMoverme = false;
				}
            }

            if(Dialogo.HeConstruidoelTelescopio == true)
            {
                if(PlayerCharacter.TengoResina == true && ((PlayerCharacter.TengoPigmentoNegro == true || PlayerCharacter.TengoPigmentoRojo == true) || (PlayerCharacter.TengoPigmentoNegro == false && PlayerCharacter. TengoPigmentoRojo == true) || (PlayerCharacter.TengoPigmentoNegro == true && PlayerCharacter. TengoPigmentoRojo == false)) == true)
                {
                    CualDigo = 3;
                }

                else
                {
                    CualDigo = 2;
                }
            }
        }

        void ActivaTransitionPoint() {
			TransitionPointActivo = true;
			TransitionPoint.enabled = true;
            TransitionPoint.Transition();
		}
    }
}
