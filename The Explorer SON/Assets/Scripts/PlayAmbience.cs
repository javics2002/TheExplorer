using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class PlayAmbience : MonoBehaviour {
	private bool isEscapePressed = false;
	EventInstance music;
	EventInstance ambience;
	EventInstance cave;
	private bool inCave = false;

	void Start() {
		StartCoroutine(PlayAmbienceAfterDelay());
	}

	IEnumerator PlayAmbienceAfterDelay() {
		while (GameManager.Instance.audioManager == null || GameManager.Instance.fmodEvents == null) {
			yield return null;
		}

		music = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Music"));
		ambience = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Ambience"));
		cave = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("CaveAmbience"));

		ambience.setParameterByName("MusicIntensity", 0.4f);
		ambience.setParameterByName("EqualisationLevel", 0.0f);
		ambience.setParameterByName("Zumbido", 0.2f);
		ambience.setParameterByName("RandomSoundsRate", 0.2f);

		music.setParameterByName("MusicIntensity", 0.30f);
		music.setParameterByName("EqualisationLevel", 0.0f);

		// Ahora GameManager est� disponible, podemos reproducir el sonido
		music.start();
		ambience.start();
	}

	void Update() {
		// Verificar si la tecla Escape ha sido presionada
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isEscapePressed = !isEscapePressed;

			if (isEscapePressed) {
				music.setParameterByName("EqualisationLevel", 1);
				ambience.setParameterByName("EqualisationLevel", 1);
				ambience.setParameterByName("Zumbido", 0.0f);
				ambience.setParameterByName("RandomSoundsRate", 0.0f);
			}
			else if (inCave) {
				music.setParameterByName("EqualisationLevel", 0.4f);
				ambience.setParameterByName("EqualisationLevel", 0.4f);
			}
			else {
				music.setParameterByName("EqualisationLevel", 0);
				ambience.setParameterByName("EqualisationLevel", 0);
				ambience.setParameterByName("Zumbido", 0.5f);
				ambience.setParameterByName("RandomSoundsRate", 0.4f);
			}
		}
	}

	public void adjustEQINCave(bool isInCave) {
		inCave = isInCave;
		if (!isInCave) {
			ambience.setParameterByName("MusicIntensity", 0.4f);
			ambience.setParameterByName("EqualisationLevel", 0.0f);
			ambience.setParameterByName("Zumbido", 0.5f);
			ambience.setParameterByName("RandomSoundsRate", 0.4f);

			music.setParameterByName("MusicIntensity", 0.3f);
			music.setParameterByName("EqualisationLevel", 0.0f);
			cave.stop(STOP_MODE.ALLOWFADEOUT);
		}
		else {
			ambience.setParameterByName("MusicIntensity", 0.1f);
			ambience.setParameterByName("EqualisationLevel", 0f);
			ambience.setParameterByName("Zumbido", 0.0f);
			ambience.setParameterByName("RandomSoundsRate", 0.0f);

			music.setParameterByName("MusicIntensity", 0.0f);
			music.setParameterByName("EqualisationLevel", 0f);

			cave.setParameterByName("MusicIntensity", 0.8f);
			cave.start();
		}
	}
}