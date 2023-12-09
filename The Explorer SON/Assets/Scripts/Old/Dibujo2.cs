using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Dibujo2 : MonoBehaviour
    {
        public float DelayTime1;
        public DialogueCanvasController DialogueCanvasController;
        public string Peticion;

        void Start()
        {
            DialogueCanvasController.ActivateCanvasWithText(Peticion);
            DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime1);
			GameManager.Instance.fmodEvents.PlayDialogue("Pregunta 2");
		}   
    }
}