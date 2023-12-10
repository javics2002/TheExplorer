using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class SoundMenu : MonoBehaviour
{
    // Start is called before the first frame update
    EventInstance music;
    EventInstance button;
    void Start()
    {
        StartCoroutine(PlayAmbienceAfterDelay());
    }

    // Update is called once per frame

    IEnumerator PlayAmbienceAfterDelay()
    {
        while (GameManager.Instance.audioManager == null || GameManager.Instance.fmodEvents == null)
        {
            yield return null;
        }

        music = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Music"));
        button = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("CorrectAnswer"));
        music.setParameterByName("MusicIntensity", 0.30f);
        music.setParameterByName("EqualisationLevel", 0.3f);

       
        music.start();
       
      
    }

    public void VFXButton()
    {
        button.start();
        music.stop(STOP_MODE.IMMEDIATE);
    }


   

}

