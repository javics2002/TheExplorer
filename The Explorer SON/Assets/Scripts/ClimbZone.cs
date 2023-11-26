using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class ClimbZone : MonoBehaviour
    {
        public PlayerCharacter PlayerCharacter;

        public void Escalar()
        {
            if(PlayerCharacter.UsoPicos == true)
            {
                PlayerCharacter.EstoyEscalando = true;
            }
        }
    }
}    