using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

[Serializable]
public class AudioEvent {
	public string name;
	public EventReference eventReference;
}

[Serializable]
public class AudioEmiter {
	public string name;
	public StudioEventEmitter emitter;
}

public class FMODEvents : MonoBehaviour
{
	public AudioEvent[] events;
	public AudioEmiter[] emitters;

	public Dictionary<string, EventReference> eventsDictionary;
	public Dictionary<string, StudioEventEmitter> emittersDictionary;

	private void Start() {
		eventsDictionary = new Dictionary<string, EventReference>();
		emittersDictionary = new Dictionary<string, StudioEventEmitter>();

		foreach (AudioEvent event_ in events) {
			eventsDictionary.Add(event_.name, event_.eventReference);
		}

		foreach (AudioEmiter emiter in emitters) {
			emittersDictionary.Add(emiter.name, emiter.emitter);
		}
	}

	public EventReference GetEvent(string key) {
		return eventsDictionary[key];
	}

	public StudioEventEmitter GetEmitter(string key) {
		return emittersDictionary[key];
	}
}
