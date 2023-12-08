using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;
using System.Runtime.InteropServices;

//https://www.fmod.com/docs/2.02/unity/examples-programmer-sounds.html

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

public class FMODEvents : MonoBehaviour {
	[SerializeField] AudioEvent[] events;
	[SerializeField] AudioEmiter[] emitters;

	public Dictionary<string, EventReference> eventsDictionary;
	public Dictionary<string, StudioEventEmitter> emittersDictionary;

	EventInstance dialogueInstance;
	EVENT_CALLBACK dialogueCallback;

	private void Start() {
		eventsDictionary = new Dictionary<string, EventReference>();
		emittersDictionary = new Dictionary<string, StudioEventEmitter>();

		foreach (AudioEvent event_ in events) {
			eventsDictionary.Add(event_.name, event_.eventReference);
		}

		foreach (AudioEmiter emiter in emitters) {
			emittersDictionary.Add(emiter.name, emiter.emitter);
		}

		// Explicitly create the delegate object and assign it to a member so it doesn't get freed
		// by the garbage collected while it's being used
		dialogueCallback = new EVENT_CALLBACK(DialogueEventCallback);
	}

	public void PlayDialogue(string key) {
		dialogueInstance = RuntimeManager.CreateInstance(eventsDictionary["Dialog"]);

		// Pin the key string in memory and pass a pointer through the user data
		GCHandle stringHandle = GCHandle.Alloc(key);
		dialogueInstance.setUserData(GCHandle.ToIntPtr(stringHandle));

		dialogueInstance.setCallback(dialogueCallback);
		dialogueInstance.start();
	}

	public void StopDialogue() {
		dialogueInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		dialogueInstance.release();
	}

	public EventReference GetEvent(string key) {
		return eventsDictionary[key];
	}

	public StudioEventEmitter GetEmitter(string key) {
		return emittersDictionary[key];
	}

	[AOT.MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
	static FMOD.RESULT DialogueEventCallback(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr) {
		EventInstance instance = new EventInstance(instancePtr);

		// Retrieve the user data
		IntPtr stringPtr;
		instance.getUserData(out stringPtr);

		// Get the string object
		GCHandle stringHandle = GCHandle.FromIntPtr(stringPtr);
		String key = stringHandle.Target as String;

		switch (type) {
			case EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND: {
				FMOD.MODE soundMode = FMOD.MODE.LOOP_NORMAL | FMOD.MODE.CREATECOMPRESSEDSAMPLE | FMOD.MODE.NONBLOCKING;
				var parameter = (PROGRAMMER_SOUND_PROPERTIES)Marshal.PtrToStructure(parameterPtr,
					typeof(PROGRAMMER_SOUND_PROPERTIES));

				if (key.Contains(".")) {
					FMOD.Sound dialogueSound;
					var soundResult = RuntimeManager.CoreSystem.createSound(Application.streamingAssetsPath + "/" + key,
						soundMode, out dialogueSound);
					if (soundResult == FMOD.RESULT.OK) {
						parameter.sound = dialogueSound.handle;
						parameter.subsoundIndex = -1;
						Marshal.StructureToPtr(parameter, parameterPtr, false);
					}
				}
				else {
					SOUND_INFO dialogueSoundInfo;
					var keyResult = RuntimeManager.StudioSystem.getSoundInfo(key, out dialogueSoundInfo);
					if (keyResult != FMOD.RESULT.OK) {
						break;
					}
					FMOD.Sound dialogueSound;
					var soundResult = RuntimeManager.CoreSystem.createSound(dialogueSoundInfo.name_or_data,
						soundMode | dialogueSoundInfo.mode, ref dialogueSoundInfo.exinfo, out dialogueSound);
					if (soundResult == FMOD.RESULT.OK) {
						parameter.sound = dialogueSound.handle;
						parameter.subsoundIndex = dialogueSoundInfo.subsoundindex;
						Marshal.StructureToPtr(parameter, parameterPtr, false);
					}
				}
				break;
			}
			case EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND: {
				var parameter = (PROGRAMMER_SOUND_PROPERTIES)Marshal.PtrToStructure(parameterPtr,
					typeof(PROGRAMMER_SOUND_PROPERTIES));
				var sound = new FMOD.Sound(parameter.sound);
				sound.release();

				break;
			}
			case EVENT_CALLBACK_TYPE.DESTROYED: {
				// Now the event has been destroyed, unpin the string memory so it can be garbage collected
				stringHandle.Free();

				break;
			}
		}
		return FMOD.RESULT.OK;
	}
}
