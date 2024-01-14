using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Puntuacion : MonoBehaviour
    {
        public static int NumeroFallos = 0;

        public void Incorrecto ()
        {
            NumeroFallos = NumeroFallos + 1;
			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("IncorrectAnswer"), transform.position);
		}
    }
}

