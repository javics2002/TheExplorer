using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class ActivateData : MonoBehaviour
    {
        public static bool Data1 = false;
        public static bool Data2 = false;
        public static bool Data3 = false;
        public static bool Data4 = false;
        public static bool Data5 = false;

        public void Aprendo1 ()
        {
            Data1 = true;
			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Notification"), transform.position);
		}

        public void Aprendo2 ()
        {
            Data2 = true;
			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Notification"), transform.position);
		}

        public void Aprendo3 ()
        {
            Data3 = true;
			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Notification"), transform.position);
		}

        public void Aprendo4 ()
        {
            Data4 = true;
			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Notification"), transform.position);
		}

        public void Aprendo5 ()
        {
            Data5 = true;
			GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Notification"), transform.position);
		}
    }
}
