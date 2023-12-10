using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

//DUDAS: Por que se baja el sonido cuando se reproduce la musica ambiente 
//Como podriamos cambiar los parametros de FMOD?
public class PlayAmbience : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isEscapePressed = false;
    EventInstance music;
    EventInstance ambience;
    void Start()
    {
        StartCoroutine(PlayAmbienceAfterDelay());
    }

    IEnumerator PlayAmbienceAfterDelay()
    {
        while (GameManager.Instance.audioManager == null || GameManager.Instance.fmodEvents == null)
        {
            yield return null;
        }

        music = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Music"));
        ambience = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Ambience"));

        ambience.setParameterByName("MusicIntensity", 0.5f);
        ambience.setParameterByName("EqualisationLevel", 0.0f);
        ambience.setParameterByName("Zumbido", 0.4f);
        ambience.setParameterByName("RandomSoundsRate", 0.4f);

        music.setParameterByName("MusicIntensity", 0.30f);
        music.setParameterByName("EqualisationLevel", 0.0f);

        // Ahora GameManager est� disponible, podemos reproducir el sonido
        music.start();
        ambience.start();
    }

    // DUDA POR QUE ESTO NO ME ESTA HACIENDO NI CASO?
    void Update()
    {
        // Verificar si la tecla Escape ha sido presionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar el valor del par�metro de ecualizaci�n al pulsar Escape
            isEscapePressed = !isEscapePressed;

            float equalizationLevel = isEscapePressed ? 1.0f : 0.0f;

       
         
            //music.setParameterByName("MusicIntensity", 0.0f);
            //ambience.setParameterByName("MusicIntensity", 0.0f);

            music.setParameterByName("EqualisationLevel", equalizationLevel);
            ambience.setParameterByName("EqualisationLevel", equalizationLevel);

            //music.stop(STOP_MODE.IMMEDIATE);
            //ambience.stop(STOP_MODE.IMMEDIATE);


        }
    }
}