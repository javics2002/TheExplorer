using UnityEngine;
using FMODUnity;
using Microsoft.CSharp.RuntimeBinder;

public class AudioManager : MonoBehaviour
{
	public void PlayOneShotSound(EventReference eventReference, Vector3 worldPosition) {
		RuntimeManager.PlayOneShot(eventReference, worldPosition);
	}
}
