using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Dibujo2 : MonoBehaviour
    {
        public float DelayTime1;
        float tiempo = 0;
        public DialogueCanvasController DialogueCanvasController;
        public string Peticion;
        public AudioSource Doblaje;
        bool PrimeraVez = true;

        void Start()
        {
            DialogueCanvasController.ActivateCanvasWithText(Peticion);
            DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime1);
            Doblaje.Play();
            PrimeraVez = false;
        }   
    }
}