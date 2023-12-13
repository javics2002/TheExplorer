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
		music = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Music"));
		ambience = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("Ambience"));
		cave = GameManager.Instance.audioManager.CreateInstance(GameManager.Instance.fmodEvents.GetEvent("CaveAmbience"));

		ambience.setParameterByName("MusicIntensity", 0.4f);
		ambience.setParameterByName("EqualisationLevel", 0.0f);
		ambience.setParameterByName("Zumbido", 0.2f);
		ambience.setParameterByName("RandomSoundsRate", 0.2f);

		music.setParameterByName("MusicIntensity", 0.30f);
		music.setParameterByName("EqualisationLevel", 0.0f);

		music.start();
		ambience.start();
	}

	private void OnDestroy() {
		ambience.stop(STOP_MODE.IMMEDIATE);
		cave.stop(STOP_MODE.IMMEDIATE);
		music.stop(STOP_MODE.IMMEDIATE);
	}

	void Update() {
		// Verificar si la tecla Escape ha sido presionada
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isEscapePressed = !isEscapePressed;

			if (isEscapePressed) {
				music.setParameterByName("EqualisationLevel", 1, true);
				ambience.setParameterByName("EqualisationLevel", 1, true);
				ambience.setParameterByName("Zumbido", 0.0f, true);
				ambience.setParameterByName("RandomSoundsRate", 0.0f, true);
			}
			else if (inCave) {
				music.setParameterByName("EqualisationLevel", 0.4f, true);
				ambience.setParameterByName("EqualisationLevel", 0.4f, true);
			}
			else {
				music.setParameterByName("EqualisationLevel", 0, true);
				ambience.setParameterByName("EqualisationLevel", 0, true);
				ambience.setParameterByName("Zumbido", 0.5f, true);
				ambience.setParameterByName("RandomSoundsRate", 0.4f, true);
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

			music.setParameterByName("EqualisationLevel", 0.0f);
			cave.stop(STOP_MODE.ALLOWFADEOUT);
		}
		else {
			ambience.setParameterByName("MusicIntensity", 0.1f);
			ambience.setParameterByName("EqualisationLevel", 0f);
			ambience.setParameterByName("Zumbido", 0.0f);
			ambience.setParameterByName("RandomSoundsRate", 0.0f);

			music.setParameterByName("EqualisationLevel", 0.4f);

			cave.setParameterByName("MusicIntensity", 0.8f);
			cave.start();
		}
	}
}