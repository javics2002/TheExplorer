using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Puntuacion : MonoBehaviour
    {
        public static int NumeroFallos = 0;
        public AudioSource Meh;

        public void Incorrecto ()
        {
            NumeroFallos = NumeroFallos + 1;
            Meh.Play();
        }
    }
}

