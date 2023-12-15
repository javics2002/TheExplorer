using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class PlayAmbience : MonoBehaviour {
	private bool isEscapePressed = false;
	EventInstance music;
	EventInstance ambience;
	EventInstance cave;
	public bool inCave = false;

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

		if(SceneManager.GetActiveScene().name == "Calar") {
			music.start();
			ambience.start();
		}

		DontDestroyOnLoad(gameObject);

		SceneManager.sceneLoaded += SceneLoaded;
	}

	private void SceneLoaded(Scene scene, LoadSceneMode loadMode) {
		switch (scene.name) {
			case "Start":
				music.stop(STOP_MODE.IMMEDIATE);

				Destroy(gameObject);
				SceneManager.sceneLoaded -= SceneLoaded;
				break;
			case "Dibujar":
				ambience.stop(STOP_MODE.IMMEDIATE);
				cave.stop(STOP_MODE.IMMEDIATE);
				break;
			case "Calar":
				music.getPlaybackState(out PLAYBACK_STATE musicState);
				if(musicState != PLAYBACK_STATE.PLAYING)
					music.start();

				ambience.getPlaybackState(out PLAYBACK_STATE ambienceState);
				if(ambienceState != PLAYBACK_STATE.PLAYING)
					ambience.start();

				ambience.setParameterByName("RandomSoundsRate", 0.5f);
				break;
			case "Estrellas":
				ambience.setParameterByName("RandomSoundsRate", 0.0f);
				break;
			default:
				ambience.setParameterByName("RandomSoundsRate", 0.2f);
				break;
		}
	}

	void Update() {
		isEscapePressed = SceneManager.sceneCount == 2;

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