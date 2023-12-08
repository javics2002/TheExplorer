using UnityEngine;
using FMODUnity;
using System.Runtime.InteropServices;
using FMOD.Studio;

public partial class AudioManager : MonoBehaviour
{
    public void PlayOneShotSound(EventReference eventReference, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(eventReference, worldPosition);
    }
    //Me gustaria saber poner parametros para poder ajustar el ambiente en funcion de la zona pero de momento esta asi

    public void SetParameter(EventReference eventReference, string parameterName, float value)
    {
		// Crear una instancia del evento
		EventInstance soundEvent = RuntimeManager.CreateInstance(eventReference); 
        SetParameterInternal(soundEvent, parameterName, value);
    }

    private void SetParameterInternal(EventInstance soundEvent, string parameterName, float value)
    {
        if (soundEvent.isValid())
        {
            soundEvent.setParameterByName(parameterName, value);
            soundEvent.start(); // Asegurarse de que el evento se haya iniciado para aplicar los cambios
            soundEvent.release(); // Importante liberar la instancia después de ajustar el parámetro
        }
        else
        {
            Debug.LogWarning($"El evento no es válido para ajustar el parámetro '{parameterName}'.");
            soundEvent.release(); // Liberar la instancia en caso de error
        }
    }
}

