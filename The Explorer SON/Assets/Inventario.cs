using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Inventario : MonoBehaviour
    {
        void Start()
        {
            if(PlayerCharacter.TengoPicos == true)
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
