using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit2D
{
    public class E : MonoBehaviour
    {
        public Image Image;

        void Update()
        {
            if(SinPicos.texto == true)
            {
                Image.enabled = true;
            }
            else
            {
                Image.enabled = false;
            }
        }
    }
}
