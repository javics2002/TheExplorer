using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DUDAS: Por que se baja el sonido cuando se reproduce la musica ambiente 
//Como podriamos cambiar los parametros de FMOD?
public class PlayAmbience : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isEscapePressed = false;
    void Awake()
    {
        StartCoroutine(PlayAmbienceAfterDelay());
    }

    IEnumerator PlayAmbienceAfterDelay()
    {
        while (GameManager.Instance == null)
        {
            // Esperar hasta que GameManager esté disponible
            yield return null;
        }

        // Ahora GameManager está disponible, podemos reproducir el sonido
        GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Ambience"), transform.position);
        GameManager.Instance.audioManager.PlayOneShotSound(GameManager.Instance.fmodEvents.GetEvent("Music"), transform.position);


        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Ambience"), "MusicIntensity",0.5f);
        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Ambience"), "EqualisationLevel", 0.0f);
        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Ambience"), "Zumbido", 0.4f);
        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Ambience"), "RandomSoundsRate", 0.4f);


        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Music"), "MusicIntensity", 0.25f);
        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Music"), "EqualisationLevel", 0.0f);
       
    }

    // DUDA POR QUE ESTO NO ME ESTA HACIENDO NI CASO?
    void Update()
    {
        // Verificar si la tecla Escape ha sido presionada
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            // Cambiar el valor del parámetro de ecualización al pulsar Escape
            isEscapePressed = !isEscapePressed;

            float equalizationLevel = isEscapePressed ? 1.0f : 0.0f;

            GameManager.Instance.audioManager.SetParameter(
                GameManager.Instance.fmodEvents.GetEvent("Ambience"),
                "EqualisationLevel",
                equalizationLevel
            );
            GameManager.Instance.audioManager.SetParameter(
              GameManager.Instance.fmodEvents.GetEvent("Music"),
              "EqualisationLevel",
              equalizationLevel
          );
            
            GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Ambience"),"MusicIntensity",0.0f);
            GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Music"),"MusicIntensity",0.0f);

        }
    }
}