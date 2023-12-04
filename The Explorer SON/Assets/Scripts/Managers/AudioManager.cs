using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

	public void PlayOneShotSound(EventReference eventReference, Vector3 worldPosition) {
		RuntimeManager.PlayOneShot(eventReference, worldPosition);
	}
	//Me gustaria saber poner parametros para poder ajustar el ambiente en funcion de la zona pero de momento esta asi

  
}

   
    

