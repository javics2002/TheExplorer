using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Poste : MonoBehaviour
    {
        public GameObject PosteUI;
        public GameObject q;
        public GameObject w;
        public GameObject e;
        public GameObject r;
        public GameObject t;
        public GameObject y;
        public GameObject u;
        public GameObject i;
        public GameObject o;
        public GameObject p;
        public GameObject s;
        public GameObject d;
        public SinPicos SinPicos;
        bool a = false;
        public static bool Acerte = false;
        public string Ayuda;
        public DialogueCanvasController DialogueCanvasController;
        public float TiempoHablar = 16f;

        void Start ()
        {
            if(Acerte == true)
            {
                q.SetActive(true);
                w.SetActive(true);
                e.SetActive(true);
                r.SetActive(false);
                t.SetActive(false);
                y.SetActive(false);
                u.SetActive(false);
                i.SetActive(false);
                o.SetActive(false);
                p.SetActive(false);
                s.SetActive(false);
                d.SetActive(false);
            }
        }

        void OnTriggerStay2D ()
        {
            if(Input.GetButtonDown("Interact"))
            {
                if(a == false)
                {
                    if (Acerte == false)
                    {
                        DialogueCanvasController.ActivateCanvasWithText(Ayuda);
                        DialogueCanvasController.DeactivateCanvasWithDelay(TiempoHablar);
                        //Doblaje.Play();
                    }
                    Dialogo.NumberD = 100;
                    SinPicos.Texto();
                    PosteUI.SetActive(true);
                    a = true;
                }
                else if (Acerte == true)
                {
                    SinPicos.CierroTexto();
                    PlayerCharacter.PuedoMoverme = true;
                    PosteUI.SetActive(false);
                    a = false;
                }
            }
        }

        public void Correcto ()
        {
            Acerte = true;
        }
    }
}