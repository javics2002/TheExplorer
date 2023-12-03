using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class BotonRojo : MonoBehaviour
    {
        void Start()
        {
            if(PlayerCharacter.TengoPigmentoRojo == true)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
