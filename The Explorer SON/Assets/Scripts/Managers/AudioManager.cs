using UnityEngine;
using FMODUnity;
using System.Runtime.InteropServices;
using FMOD.Studio;
using System.Collections.Generic;
using System.Data;

public partial class AudioManager : MonoBehaviour
{
    List<EventInstance> eventInstances;

    private void Awake()
    {
        eventInstances = new List<EventInstance>();
    }

    private void OnDestroy()
    {
        foreach (EventInstance instance in eventInstances)
        {
            instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            instance.release();
        }
    }

    public void PlayOneShotSound(EventReference eventReference, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(eventReference, worldPosition);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
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
    public void PlayOneShotSoundInBus(EventReference eventReference, string busName, Vector3 worldPosition)
    {
        FMOD.Studio.Bus bus = FMODUnity.RuntimeManager.GetBus(busName);

        bus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Detener eventos anteriores en el bus
        bus.setPaused(false); // Asegurarse de que el bus no esté en pausa

        RuntimeManager.PlayOneShot(eventReference, worldPosition);

    }
  
}

