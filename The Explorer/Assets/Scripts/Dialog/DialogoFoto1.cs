using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using System;

namespace Gamekit2D
{
    public class DialogoFoto1 : MonoBehaviour
    {
        public DialogueCanvasController DialogueCanvasController;
        static bool EsLaPrimeraVez = true;
        public float DelayTime1;
        float tiempo = 0;
        public string Dialogo1;

        void Start()
        {
            if(EsLaPrimeraVez == true)
            {
                DialogueCanvasController.ActivateCanvasWithText(Dialogo1);
                DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime1);
                EsLaPrimeraVez = false;
                FPPlayer.PuedoMoverme = false;
                VerCamControl.PuedoMoverme = false;
				GameManager.Instance.fmodEvents.PlayDialogue("Foto1");
			}
            else
            {
                FPPlayer.PuedoMoverme = true;
                VerCamControl.PuedoMoverme = true;
            }
        }

        void Update()
        {
            tiempo = tiempo + 1 * Time.deltaTime;
            if(tiempo > DelayTime1)
            {
                FPPlayer.PuedoMoverme = true;
                VerCamControl.PuedoMoverme = true;
            }
        }
    }
}

