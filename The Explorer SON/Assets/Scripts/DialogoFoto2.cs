using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using System;

namespace Gamekit2D
{
    public class DialogoFoto2 : MonoBehaviour
    {
        public DialogueCanvasController DialogueCanvasController;
        static bool EsLaPrimeraVez = true;
        public float DelayTime1;
        float tiempo = 0;
        public string Dialogo1;
        public AudioSource Doblaje;

        void Start()
        {
            if(EsLaPrimeraVez == true)
            {
                DialogueCanvasController.ActivateCanvasWithText(Dialogo1);
                DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime1);
                EsLaPrimeraVez = false;
                FPPlayer.PuedoMoverme = false;
                VerCamControl.PuedoMoverme = false;
                Doblaje.Play();
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
/*
            if(-185 > Capsule.Rotation.Y > -205 && -10 > Camera.Rotation.X > -15)
            {
                Debug.Log("Correct boii");
            }

            
            if(HeEntradoAlCollider == true)
            {
                tiempo2 = tiempo2 + 1 * Time.deltaTime;
                FPPlayer.PuedoMoverme = false;
                VerCamControl.PuedoMoverme = false;
                DialogueCanvasController.ActivateCanvasWithText("Esto es lo que quería ver yo");
                DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime2);
                if(tiempo2 > DelayTime2) //if(tiempo2 es mayor a la suma de todos los delaytime (2, 3, 4...))
                {
                    FPPlayer.PuedoMoverme = true;
                    VerCamControl.PuedoMoverme = true;
                    HeEntradoAlCollider = false;
                }
            }
            */
        }

        /*
        public void EntroAlCollider ()
        {
            Debug.Log("Casi");
            if (EsLaPrimeraVez == true)
            {
                Debug.Log("Funcionaaaa");
                HeEntradoAlCollider = true;
                EsLaPrimeraVez = false;
            }
        }
        */
    }
}