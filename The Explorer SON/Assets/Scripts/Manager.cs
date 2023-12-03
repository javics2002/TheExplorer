using UnityEngine;

public class Manager : MonoBehaviour
{
	public static Manager instance;
	public AudioManager audioManager;
	public FMODEvents fmodEvents;

	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	private void Start() {
		audioManager = GetComponentInChildren<AudioManager>();
		fmodEvents = GetComponentInChildren<FMODEvents>();
	}
}
