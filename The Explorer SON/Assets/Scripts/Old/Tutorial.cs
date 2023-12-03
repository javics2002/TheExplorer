using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Tutorial : MonoBehaviour
    {
        static bool inicio = true;
        public GameObject imagen;

        void Start()
        {
            if (inicio == true)
            {
                PlayerCharacter.PuedoMoverme = false;
            }
            else
            {
                imagen.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (inicio == true && Input.GetButton("Interact"))
            {
                inicio = false;
                PlayerCharacter.PuedoMoverme = true;
                imagen.SetActive(false);
            }
        }
    }
}

