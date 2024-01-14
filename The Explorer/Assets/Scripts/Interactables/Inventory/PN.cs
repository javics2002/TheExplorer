using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class PN : MonoBehaviour
    {
        void Start()
        {
            if(PlayerCharacter.TengoPigmentoNegro == true)
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
