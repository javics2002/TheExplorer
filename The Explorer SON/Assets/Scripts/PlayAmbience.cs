using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DUDAS: Por que se baja el sonido cuando se reproduce la musica ambiente 
//Como podriamos cambiar los parametros de FMOD?
public class PlayAmbience : MonoBehaviour
{
    // Start is called before the first frame update
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


        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Ambience"), "AmbienceIntensity",0.1f);
        GameManager.Instance.audioManager.SetParameter(GameManager.Instance.fmodEvents.GetEvent("Music"), "MusicIntensity", 0.1f);



    }

    // Update is called once per frame
    void Update()
    {

    }



}