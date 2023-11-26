using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Video : MonoBehaviour
    {
        public float DelayTime1;
        public float DelayTime2;
        float tiempo = 0;
        public GameObject panel;
        public DialogueCanvasController DialogueCanvasController;
        public string Peticion;
        public AudioSource Doblaje;
        bool PrimeraVez = true;

        void Update()
        {
            tiempo = tiempo + 1 * Time.deltaTime;
            if(tiempo > DelayTime1 && PrimeraVez == true)
            {
                panel.SetActive(false);
                DialogueCanvasController.ActivateCanvasWithText(Peticion);
                DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime2);
                Doblaje.Play();
                PrimeraVez = false;
            }
        }   
    }
}

