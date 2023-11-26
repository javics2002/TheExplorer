using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Sound : MonoBehaviour
    {
        public AudioSource N;

        public void PlayNotification()
        {
            N.Play();
        }
    }
}

