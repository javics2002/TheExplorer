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
        bool PrimeraVez = true;

		private void Start() {
            GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("VideoPinturasRupestres"), transform.position);
		}

		void Update()
        {
            tiempo = tiempo + 1 * Time.deltaTime;
            if(tiempo > DelayTime1 && PrimeraVez == true)
            {
                panel.SetActive(false);
                DialogueCanvasController.ActivateCanvasWithText(Peticion);
                DialogueCanvasController.DeactivateCanvasWithDelay(DelayTime2);
				GameManager.Instance.fmodEvents.PlayDialogue("Dibujo1");
				PrimeraVez = false;
            }
        }   
    }
}

