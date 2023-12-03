using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class MovimientoLibre : MonoBehaviour
    {
        void Start ()
        {
            FPPlayer.PuedoMoverme = true;
            VerCamControl.PuedoMoverme = true;
        }
    }
}

